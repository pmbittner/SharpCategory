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
    }
}