{-# LANGUAGE TypeFamilies, ScopedTypeVariables #-}

module Challenge14 where

import Challenge

challenge14 :: Challenge
challenge14 = Challenge {
    run =
        "          square  3 = " <> (show $ square 3) <> "\n" <>
        "(memoized square) 3 = " <> (show $ memSquare 3)
        }

class Representable f where
    type Rep f :: *
    tabulate :: (Rep f -> x) -> f x
    index :: f x -> Rep f -> x

{- 1.
Show that the hom-functors map identity morphisms in C to corresponding identity functions in Set.

If C is empty, the theorem trivially holds.
Thus, assume C is not empty.
Let a be an arbitrary object in C.
We get C(a, -) is the hom-functor at a.
Let x be another object in C.
Because C(a, -) is a hom-functor, we know that for all morphisms h from a to x, is mapped to
C(a, f) h = f . h  for any morphism from x to another object.
For f = id, we get C(a, id) h = id . h = h.

(I am not quite sure that this solution is clean, complete, and correct. :/)
-}

{- 2.
Show that Maybe is not representable.

Maybe has either 0 or 1 value.
Maybe can thus store one piece of information and thus could represent a type with one value (e.g., unit).
However, any type that can be empty (e.g., Maybe, List) cannot be inverted as no value can be memoized in this case.
-}
instance Representable Maybe where
    type Rep Maybe = ()
    tabulate f = Just (f ())
    index (Just x) () = x
    index Nothing () = error "Cannot construct x"

{- 3.
Is the Reader functor representable?

Yes because reader is a function type which is isomorphic to the hom functor.
-}
data Reader a x = Reader (a -> x)
instance Representable (Reader a) where
    type Rep (Reader a) = a
    tabulate f = Reader f
    index (Reader f) = f


{- 4.
Using Stream representation, memoize a function that squares its argument.
-}
data Stream a = Cons a (Stream a)
instance Representable Stream where
    type Rep Stream = Integer
    tabulate f = Cons (f 0) (tabulate (f . (+1)))
    index (Cons b bs) n = if n == 0 then b else index bs (n - 1)

memoized :: forall x. (Integer -> x) -> Integer -> x
memoized f i =
    let s :: (Stream x) = tabulate f in
    index s i

square :: Integer -> Integer
square i = i*i
memSquare :: Integer -> Integer
memSquare = memoized square

{- 5.
Show that tabulate and index for Stream are indeed the inverse of each other. (Hint: use induction.)

Theorem: For any function f :: Integer -> x, the following should hold: index (tabulate f) n = f n.
Proof by induction:
Let n = 0:
  index (tabulate f) 0 = index (Cons (f 0) (tabulate (f . (+1)))) 0 // definition of tabulate
                       = if n == 0 then (f 0) else index (tabulate (f . (+1))) (n - 1) // definition of index
                       = f 0 // because we assumend n to be 0
Assume that index (tabulate f) n = f n for any n >= 0.
We show that index (tabulate f) (n+1) = f (n+1):
  index (tabulate f) (n+1) = index (Cons (f 0) (tabulate (f . (+1)))) (n+1) // definition of tabulate
                           = if (n+1) == 0 then (f 0) else index (tabulate (f . (+1))) ((n+1) - 1) // definition of index
                           = index (tabulate (f . (+1))) ((n+1) - 1) // because n>=0, we know that n+1>0
                           = index (tabulate (f . (+1))) n // simplify arithmetically
                           = (f . (+1)) n // induction step
                           = f (n+1) // re-order terms
-}

{- 6.
The functor
Pair a = Pair a a
is representable. Can you guess the type that represents it? Implement tabulate and index.

A Pair holds two values. It thus holds enough information to memoize two values.
It can thus represent (and is represented by (because of isomophism)) by an two-valued type,
the prime example being Bool.
-}
data Pair a = Pair a a
instance Representable Pair where
    type Rep Pair = Bool
    tabulate h = Pair (h True) (h False)
    index (Pair x y) b = if b then x else y
