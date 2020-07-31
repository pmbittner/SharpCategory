using System.Security.Cryptography;

namespace SharpCategory.Challenge5
{
    public class Challenge : SharpCategory.Challenge
    {
        public int ChapterNo { get; } = 5;

        public void Run() {}

        private static int i(int n)
        {
            return n;
        }

        private static int j(bool b)
        {
            return b ? 0 : 1;
        }

        /*
         * Answer to 6:
         * int with i and j cannot be a "better" co-product than Either<int, bool> because
         *  - we cannot differentiate for ints 0 and 1 if they are injections of an int (via i) or of a bool (via j).
         *  - there exists this m
         */
        private static int m(Either<int, bool> e)
        {
            return e.IsLeft ? e.Left : e.Right ? 0 : 1;
        }

        /*
         * Answer to 7:
         * int with i2 and j cannot be a "better" co-product than Either<int, bool> because
         *  - there exists this m
         */
        private static int m2(Either<int, bool> e)
        {
            return e.IsLeft ?
                e.Left < 0 ? e.Left : e.Left + 2
                :
                e.Right ? 0 : 1;
        }
        
        /* Possible solutions for task 8 */
        
        /* Let a candidate for a co-product be bool with
         *   bool i(int x) { return x > 0; }
         *   bool j(bool y) { return y; }
         *
         * Then both of the following factorizations m to Either would be possible:
         */
        private static Either<int, bool> m1_bool(bool b)
        {
            return new Either<int, bool>(b);
        }
        
        private static Either<int, bool> m2_bool(bool b)
        {
            // If b is is positive if could have corresponded to a positive integer according to i.
            return new Either<int, bool>(b ? 1 : 0);
        }
        
        /*
         * In summary:
         * If there are multiple possible factorizations from a co-product candidate X to
         * another co-product candidate Y, then we already lost information in X that we cannot reconstruct.
         * Hence, the ambiguity of multiple factorizations occure.
         * The actual co-product is the sweet spot that exactly contains
         *   - enough information to represent both initial objects (there are no multiple factorizations to another
         *     candidate)
         *   - the minimal amount of information to be a co-product (there is a unique factorization to all the other
         *     candidates)
         */
    }
}