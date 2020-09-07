module Challenge10 where

import Challenge
import Control.Monad.Reader

challenge10 :: Challenge
challenge10 = Challenge { run = "Challenge 10 has nothing to report." }

{-
Task 1: Define a natural transformation from the Maybe functor to the List functor.
Prove the naturality condition for it.
-}
pack :: Maybe a -> [a]
pack Nothing = []
pack (Just x) = [x]
{-
fmap f (pack Nothing) = fmap f [] = []
pack (fmap f Nothing) = pack Nothing = []

fmap f (pack (Just x)) = fmap f [x] = [f x]
pack (fmap f (Just x)) = pack (Just (f x)) = [f x]
-}

{-
Task 2: Define at least two natural transformations between Reader () and the list functor.
How many different lists of () are there?
-}
never :: Reader () a -> [a]
never _ = []

once :: Reader () a -> [a]
once r = [runReader r ()]

twice :: Reader () a -> [a]
twice r = [runReader r (), runReader r ()]
-- There are as many natural transformations from Reader () to list as there are natural numbers.

{-
Task 3: Continue the previous exercise with Reader Bool and Maybe.
-}
takeTrue :: Reader Bool a -> Maybe a
takeTrue r = Just $ runReader r True

takeFalse :: Reader Bool a -> Maybe a
takeFalse r = Just $ runReader r False

discard :: Reader Bool a -> Maybe a
discard _ = Nothing
{-
There are three natural transformation. We can plug in True or False to the Reader or discard it to return Nothing.
As predicted by the Yoneda Lemma, these three Functions correspond to the elements of Maybe Bool: True, False, Nothing.
-}