using System;
using SharpCategory.Challenge4;
using SharpCategory.Challenge5;
using SharpCategory.Challenge6;

namespace SharpCategory.Challenge8
{
    public class Challenge : SharpCategory.Challenge
    {
        public int ChapterNo { get; } = 8;

        public void Run()
        {
            Either<Const<Unit, int>, Identity<int>> eitherR
                = Either<Const<Unit, int>, Identity<int>>.ConsRight(
                    new Identity<int>(7));
            Either<Const<Unit, int>, Identity<int>> eitherL
                = Either<Const<Unit, int>, Identity<int>>.ConsLeft(
                    new Const<Unit, int>(Unit.Instance));

            foreach (Either<Const<Unit, int>, Identity<int>> either in new[] {eitherR, eitherL})
            {
                Console.WriteLine($"      e = {either}");
                Console.WriteLine($"   f(e) = {f(either)}");
                Console.WriteLine($"g(f(e)) = {g(f(either))}\n");
            }
        }

        /**
         * Task 2: Show the isomorphism between the standard definition of Maybe and this desugaring:
         *   type Maybe' a = Either (Const () a) (Identity a).
         * Hint: Define two mappings between the two implementations.
         * For additional credit, show that they are the inverse of each other using equational reasoning.
         *
         * f(g(ConsLeft(new Const<Unit, A>(Unit.Instance)))
         * = f(new Maybe<A>())
         * = ConsLeft(new Const<Unit, A>(Unit.Instance))
         *
         * f(g(ConsRight(new Identity<A>(val))))
         * = f(new Maybe<A>(val))
         * = ConsRight(new Identity<A>((new Maybe<A>(val)).Value))
         * = ConsRight(new Identity<A>(val))
         */
        Maybe<A> f<A>(Either<Const<Unit, A>, Identity<A>> either)
        {
            if (either.IsLeft)
            {
                return new Maybe<A>();
            }
            return new Maybe<A>(either.Right.Value);
        }

        Either<Const<Unit, A>, Identity<A>> g<A>(Maybe<A> maybe)
        {
            if (maybe.IsValid)
            {
                return Either<Const<Unit, A>, Identity<A>>.ConsRight(new Identity<A>(maybe.Value));
            }
            return Either<Const<Unit, A>, Identity<A>>.ConsLeft(new Const<Unit, A>(Unit.Instance));
        }
        
        /**
         * Task 4: [...] For additional credit check your solution against Conor McBride's paper
         * "Clowns to the Left of me, Jokers to the Right" at (http://strictlypositive.org/CJ.pdf).
         *
         * My implementations
         * K2.Bimap
         * Fst.Bimap
         * Snd.Bimap
         * equal those of Conor, translated to C#.
         */
        
        /**
         * Task 5: Define a bifunctor in a language other than Haskell.
         * Implement bimap for a generic pair in that langauge.
         *
         * We cant implement a generic interface for Bifunctors in C# because we cannot specify
         * that a generic argument itself should be generic.
         * We cant do this template<template<...>, ...> as in C++ or Haskell.
         *
         * The implementation of Bimap for a Pair can be found in Pair.cs.
         */
        
        /**
         * Task 6: Should std::map be considered a bifunctor or a profunctor in the two
         * template arguments Key and T. How would you redesign this data type to make it so?
         *
         * A Map can be seen as a list of pairs. As pairs are bifunctors one could implement bimap as
         * bimap g h m = new Map(m.entryList.fmap(Pair.bimap(g, h)));
         * This is easier in Haskell because of currying.
         *
         * However, this could break the constraints of a map.
         * If g is not injective, then the same key can occur multiple times which is illegal.
         * So I would argue that std::map is not an instance of Bifunctor because its bimap cannot
         * accept non-injective functions.
         *
         * To show that std::map is a profunctor, we have to implement lmap.
         * lmap gets an inverse function "U -> Key" where U is any type.
         * One could see a std::map as a function table "Key -> T" and then join both functions to get the new map
         * lmap (U -> Key) (Key -> T) = 
         * = (Key -> T).(U -> Key)
         * = U -> T
         * but we dont know which keys actually to store in this map because we cannot invert (U -> Key).
         * If one would implement a wrapper map that wraps the old map and first computes (U -> Key) and then
         * accesses the wrapped old map (Key -> T), lmap could be implemented.
         * But that is not possible with just using std::map, I suppose.
         * So if one would alter std::map to contain a key-preprocessing function (U -> Key),
         * this altered version of std::map would be a profunctor.
         */
    }
}