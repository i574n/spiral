module spiral_compiler =
    let outer env value =
        let helper x = env + x
        let result = helper value
        // padding 01
        // padding 02
        // padding 03
        // padding 04
        // padding 05
        // padding 06
        // padding 07
        // padding 08
        // padding 09
        // padding 10
        // padding 11
        // padding 12
        // padding 13
        // padding 14
        // padding 15
        // padding 16
        // padding 17
        // padding 18
        // padding 19
        // padding 20
        // padding 21
        // padding 22
        // padding 23
        // padding 24
        // padding 25
        // padding 26
        // padding 27
        // padding 28
        // padding 29
        // padding 30
        // padding 31
        // padding 32
        // padding 33
        // padding 34
        // padding 35
        // padding 36
        // padding 37
        // padding 38
        // padding 39
        // padding 40
        // padding 41
        // padding 42
        // padding 43
        // padding 44
        // padding 45
        // padding 46
        // padding 47
        // padding 48
        // padding 49
        // padding 50
        // padding 51
        // padding 52
        // padding 53
        // padding 54
        // padding 55
        result

    let answer = outer 40 2
    if answer <> 42 then failwith $"unexpected: {answer}"
    printfn "bounded-lift:%d" answer
