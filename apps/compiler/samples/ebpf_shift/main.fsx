let v0 : int32 = -8
let v1 : int32 = 3
let v2 : int32 = 1
let v3 : uint32 = 4294967295u
let v4 : int32 = 4
let v5 : int32 = v0 >>> v2
let v6 : int32 = v1 <<< v2
let v7 : uint32 = v3 >>> v4
let v8 : uint32 = v3 <<< v2
let v9 : bool = v5 = -4
if v9 then
    let v10 : bool = v6 = 6
    if v10 then
        let v11 : bool = v7 = 268435455u
        if v11 then
            let v12 : bool = v8 = 4294967294u
            if v12 then
                0
            else
                4
        else
            3
    else
        2
else
    1
