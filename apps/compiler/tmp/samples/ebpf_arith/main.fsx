let v0 : int32 = 7
let v1 : int32 = 2
let v2 : uint32 = 4294967295u
let v3 : int32 =  -v0
let v4 : int32 = -3
let v5 : int32 = -12
let v6 : int32 = -4
let v7 : int32 = -1
let v8 : int32 = v3 / v1
let v9 : bool = v8 = v4
if v9 then
    let v10 : int32 = v3 % v1
    let v11 : bool = v10 = v7
    if v11 then
        let v12 : int32 = v3 >>> 1
        let v13 : bool = v12 = v6
        if v13 then
            let v14 : int32 = v4 <<< 2
            let v15 : bool = v14 = v5
            if v15 then
                let v16 : uint32 = v2 + 1u
                let v17 : bool = v16 = 0u
                if v17 then
                    let v18 : uint32 = v2 * v2
                    let v19 : bool = v18 = 1u
                    if v19 then
                        let v20 : uint32 = v2 >>> 28
                        let v21 : bool = v20 = 15u
                        if v21 then
                            0
                        else
                            7
                    else
                        6
                else
                    5
            else
                4
        else
            3
    else
        2
else
    1
