using System;

namespace SharpCategory.Challenge1
{
    public class Challenge : SharpCategory.Challenge
    {
        public int ChapterNo { get; } = 1;
        
        private static void TestComposition<A, B, C>(Function<A, B> f, Function<B, C> g, A x)
        {
            Console.WriteLine();
            Console.WriteLine($"    f({x})  = {f(x)}");
            Console.WriteLine($"  g(f({x})) = {g(f(x))}");
            Console.WriteLine($"(g.f)({x})  = {Functions.Composition(g, f)(x)}");
        }

        private static void TestId<T>(T val)
        {
            // We cannot assume T to be comparable.
            Console.WriteLine($"id({val}) = {Functions.Identity(val)}");
        }

        private static void TestIfCompositionRespectsIdentity<A, B>(Function<A, B> f, A a)
        {
            Console.WriteLine($"       f({a}) = {f(a)}");
            Console.WriteLine($"(id . f)({a}) = {Functions.Composition(Functions.Identity, f)(a)}");
            Console.WriteLine($"(f . id)({a}) = {Functions.Composition<A, A, B>(f, Functions.Identity)(a)}");
        }

        public void Run()
        {
            TestId(false);
            TestId(true);
            TestId(1);
            TestId("FuNcTionZZ");

            TestComposition(x => x + 1, x => $"It's {x}!", 0);
            TestComposition(x => x != 0, x => x ? 1 : 0, 0);

            TestIfCompositionRespectsIdentity(x => x + 3, 5);
            TestIfCompositionRespectsIdentity(x => !x, true);
        }
    }
}