using System.IO;

namespace SharpCategory.Challenge8
{
    public class Pair<A, B>
    {
        public Pair(A fst, B snd)
        {
            this.fst = fst;
            this.snd = snd;
        }

        public A fst
        {
            get;
        }

        public B snd
        {
            get;
        }

        /**
         * Let p = (a, b) be a Pair<A, B>,
         *     g be a Function<A, C>,
         *     and h be a Function<B, D>.
         *
         * p.Second(h).First(g)
         * = q.First(g) where q = (g(a), b)
         * = (g(a), h(b))
         * = p.Bimap(g, h)
         */
        public Pair<C, D> Bimap<C, D>(Function<A, C> g, Function<B, D> h)
        {
            return new Pair<C, D>(g(fst), h(snd));
        }

        /**
         * Let p = (a, b) be a Pair<A, B>,
         *     and g be a Function<A, C>.
         *
         * p.Bimap(g, id)
         * = (g(a), id(b))
         * = (g(a), b)
         * = p.First(g)
         */
        public Pair<C, B> First<C>(Function<A, C> f)
        {
            return new Pair<C, B>(f(fst), snd);
        }

        /**
         * Let p = (a, b) be a Pair<A, B>,
         *     and g be a Function<A, C>.
         *
         * p.Bimap(id, h)
         * = (id(a), h(b))
         * = (a, h(b))
         * = p.Second(g)
         */
        public Pair<A, D> Second<D>(Function<B, D> g)
        {
            return new Pair<A, D>(fst, g(snd));
        }
    }
}