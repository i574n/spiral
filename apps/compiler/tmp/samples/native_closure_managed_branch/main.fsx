let main =
    let invoke (captured : string, bias : int) (value : int) = captured.Length + value + bias
    let left = ("abc", 0)
    let right = ("wxyz", -1)
    let flag = true
    let selected = if flag then left else right
    invoke selected 39

main
