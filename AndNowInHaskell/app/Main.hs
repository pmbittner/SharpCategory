module Main where

import Challenge
import Challenge10
import Data.List

main :: IO ()
main = putStrLn $ intercalate "\n\n" $ run <$> [challenge10]