using System;
using SharpCategory.Challenge4;
using SharpCategory.Challenge5;

namespace SharpCategory.Challenge6
{
    public class Challenge : SharpCategory.Challenge
    {
        public int ChapterNo { get; } = 6;

        public void Run()
        {
            Console.WriteLine(">> TestMaybeEitherIsomorphism");
            TestMaybeEitherIsomorphism(Either<Unit, string>.ConsRight("Fun"));
            TestMaybeEitherIsomorphism(Either<Unit, string>.ConsLeft(new Unit()));

            Console.WriteLine(">> TestSumIsomorphism");
            TestSumIsomorphism(new Tuple<bool, int>(false, 7));
            TestSumIsomorphism(new Tuple<bool, string>(true, "hi"));
        }
        
        /* Task 1: Show the isomorphism between Maybe<A> and Either<Void, A> */

        Maybe<A> ToMaybe<A>(Either<Unit, A> e)
        {
            return e.IsLeft ? 
                new Maybe<A>() :
                new Maybe<A>(e.Right);
        }

        Either<Unit, A> ToEither<A>(Maybe<A> a)
        {
            return a.IsValid ?
                Either<Unit, A>.ConsRight(a.Value) :
                Either<Unit, A>.ConsLeft(new Unit());
        }
        
        private void TestMaybeEitherIsomorphism<A>(Either<Unit, A> e)
        {
            Console.WriteLine($"e = {e}");
            Console.WriteLine($"ToMaybe(t) = {ToMaybe(e)}");
            Console.WriteLine($"ToEither(ToMaybe(t)) = {ToEither(ToMaybe(e))}");
            Console.WriteLine();
        }
        
        /*
         * Task 5: Show that a + a = 2a holds for types (up to isomorphism).
         * Remember that 2 corresponds to Bool, according to our translation table.
         */

        Either<A, A> ToSum<A>(Tuple<bool, A> product)
        {
            return product.Item1 ? Either<A, A>.ConsLeft(product.Item2) : Either<A, A>.ConsRight(product.Item2);
        }
        
        Tuple<bool, A> ToProduct<A>(Either<A, A> product)
        {
            return new Tuple<bool, A>(product.IsLeft, product.IsLeft ? product.Left : product.Right);
        }

        private void TestSumIsomorphism<A>(Tuple<bool, A> t)
        {
            Console.WriteLine($"t = {t}");
            Console.WriteLine($"ToSum(t) = {ToSum(t)}");
            Console.WriteLine($"ToProduct(ToSum(t)) = {ToProduct(ToSum(t))}");
            Console.WriteLine();
        }
    }
}