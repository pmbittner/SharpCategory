using System;

namespace SharpCategory.Challenge7
{
    public class Challenge : SharpCategory.Challenge
    {
        public int ChapterNo { get; } = 7;

        public void Run()
        {
            Function<Object, string> welcome = x => $"Welcome {x}!";

            Function<int, string> welcomeSquare = Reader<int>.fmap(welcome)(x => x*x);
            Console.WriteLine(welcomeSquare(3));

            welcomeSquare = Reader<int>.fmap_curried(x => x * x, welcome);
            Console.WriteLine(welcomeSquare(5));
        }
        
        /*
         * Task 1: Can we turn the Maybe type constructor into a functor by defining
         *   fmap _ _ = Nothing
         * which ignores both of its arguments? (Hint: Check the functor laws.)
         *
         * So in C# this would look like:
         *   Function<Maybe<A>, Maybe<B>> fmap<A, B>(Function<A, B> f) {
         *     return a => new Maybe(); // Nothing
         *   }
         *
         * Functors have to preserve Identity:
         *   fmap id = id
         * or
         *   (fmap id) Maybe a = id Maybe a = Maybe a
         * or in C#: For any Maybe<A> a
         *   fmap<A, A>(Identity<A>)(a) = Identity<Maybe<A>>(a) = a
         *
         * This is not the case if a.IsValid() because:
         *   - fmap<A, A>(Identity<A>)(a) returns (new Maybe<A>())
         *   - Identity<Maybe<A>>(a) returns a
         *   - a.IsValid() != (new Maybe<A>()).IsValid()
         */
        
        /*
         * Task 2: Prove functor laws for the reader functor. Hint: it's really simple.
         *
         * Reader is a function type (->) r parameterised by a, so reader is a functor on a.
         * So, a reader describes functions that return objects of type a given an instance of r.
         * fmap :: (a -> b) -> ((r -> a) -> (r -> b))
         * with
         * fmap f g = f . g
         *
         * The following laws have to be satisfied:
         * Let x = (r -> a) be a Reader
         * 1.) Identity: fmap id = id
         *   With equational reasoning we get:
         *   fmap id x
         *     = id . x // by definition of fmap
         *     = x      // because id is the neutral element of function composition
         *     = id x   // by definition of id
         *
         * 2.) Composition: fmap (f . g) = (fmap f) . (fmap g)
         *   With equational reasoning we get:
         *   fmap (f . g) x
         *     = (f . g) . x             // by definition of fmap
         *     = f . (g . x)             // associativity
         *     = f . (fmap g x)          // by definition of fmap
         *     = fmap f (fmap g x)       // by definition of fmap and because (fmap g x) is a reader again
         *     = ((fmap f) . (fmap g)) x // by definition of composition
         */
        
        /*
         * Task 4: Prove the functor laws for the list functor.
         * Assume that the laws are true for the tail part of the list you're applying it to
         * (in other words, use induction).
         *
         * To remember:
         * data List a = Nil | Cons a (List a)
         * fmap :: (a -> b) -> (List a -> List b)
         * fmap f Nil = Nil
         * fmap f (Cons h t) = Cons (f h) (fmap f t)
         *
         * 1.) Identity: fmap id = id
         * Case 1 - Nil
         *   fmap id Nil
         *     = Nil     // by definition of fmap
         *     = id Nil  // by definition of id
         *
         * Case 2 - (Cons h t)
         *   Assumption for induction: "fmap id t = id t" for tail t of a list
         *   fmap id (Cons h t)
         *     = Cons (id h) (fmap id t) // by definition of fmap
         *     = Cons (id h) (id t)      // inductive step
         *     = Cons h t                // by definition of id
         *     = id (Cons h t)           // by definition of id
         *
         * 2.) Composition: fmap (f . g) = (fmap f) . (fmap g)
         * Case 1 - Nil
         *   fmap (f . g) Nil
         *     = Nil                       // by definition of fmap
         *     = fmap g Nil                // by definition of fmap
         *     = fmap f (fmap g Nil)       // by definition of fmap
         *     = ((fmap f) . (fmap g)) Nil // by definition of composition
         *
         * Case 2 - (Cons h t)
         *   Assumption for induction: "fmap (f . g) t = ((fmap f) . (fmap g)) t" for tail t of a list
         *   Let's do it backwards:
         * 
         *   ((fmap f) . (fmap g)) (Cons h t)
         *     = fmap f (fmap g (Cons h t))                 // by definition of composition
         *     = fmap f (Cons (g h) (fmap g t))             // by definition of fmap
         *     = Cons (f (g h)) (fmap f (fmap g t))         // by definition of fmap
         *     = Cons ((f . g) h) (((fmap f) . (fmap g)) t) // by definition of composition
         *     = Cons ((f . g) h) (fmap (f . g) t)          // inductive step
         *     = fmap (f . g) (Cons h t)                    // by definition of fmap
         */
    }
}