﻿namespace Kata.Kyu6

// https://www.codewars.com/kata/556deca17c58da83c00002db

open NUnit.Framework
open FsUnit

module TribonacciSequence =
    let tribonacci signature n = 
        let seed = match signature with | [x;y;z] -> (x,y,z) | _ -> (0,0,0)
        (signature |> Seq.append <| Seq.unfold
        (fun (x,y,z) -> 
            let el = x+y+z
            Some(el, (y,z,el))
        ) seed)
        |> Seq.truncate n
        |> Seq.toList

    [<Test>]
    let ``Tribonacci Sequence`` () =
        tribonacci [1;1;1] 10 |> should equal [1;1;1;3;5;9;17;31;57;105]
        tribonacci [0;0;1] 10 |> should equal [0;0;1;1;2;4;7;13;24;44]
        tribonacci [0;1;1] 10 |> should equal [0;1;1;2;4;7;13;24;44;81]
        tribonacci [1;0;0] 10 |> should equal [1;0;0;1;1;2;4;7;13;24]
        tribonacci [0;0;0] 10 |> should equal [0;0;0;0;0;0;0;0;0;0]
        tribonacci [1;2;3] 10 |> should equal [1;2;3;6;11;20;37;68;125;230]
        tribonacci [3;2;1] 10 |> should equal [3;2;1;6;9;16;31;56;103;190]
        tribonacci [1;1;1] 1 |> should equal [1]
        tribonacci [300;200;100] 0 |> should be Empty