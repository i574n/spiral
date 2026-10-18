import gleam/float
@external(erlang, "math", "atan2")
fn spiral_math_atan2(y: Float, x: Float) -> Float
pub fn main() {
let v0 = 2.7
let v1 = 3.2
let v2 = -2.5
let v3 = 3.5
let v4 = 0.5
let v5 = 1.0
let v6 = 2.7
let v7 = float.floor
let v8 = v7( v0  )
let v9 = v8 == 2.0
let v10 = v9 != True
case v10 {
    True -> {
        1
    }
    False -> {
        let v11 = float.ceiling
        let v12 = v11( v0  )
        let v13 = v12 == 3.0
        let v14 = v13 != True
        case v14 {
            True -> {
                2
            }
            False -> {
                let v15 = float.floor
                let v16 = v15( v0  )
                let v17 = v0 -. v16
                let v18 = v17 >. 0.5
                let v29 =
                    case v18 {
                        True -> {
                            let v19 = v16 +. 1.0
                            v19
                        }
                        False -> {
                            let v20 = v17 <. 0.5
                            case v20 {
                                True -> {
                                    v16
                                }
                                False -> {
                                    let v21 = v16 /. 2.0
                                    let v22 = float.floor
                                    let v23 = v22( v21  )
                                    let v24 = v23 *. 2.0
                                    let v25 = v24 == v16
                                    case v25 {
                                        True -> {
                                            v16
                                        }
                                        False -> {
                                            let v26 = v16 +. 1.0
                                            v26
                                        }
                                    }
                                }
                            }
                        }
                    }
                let v30 = v29 == 3.0
                let v31 = v30 != True
                case v31 {
                    True -> {
                        3
                    }
                    False -> {
                        let v32 = float.floor
                        let v33 = v32( v1  )
                        let v34 = v1 -. v33
                        let v35 = v34 >. 0.5
                        let v46 =
                            case v35 {
                                True -> {
                                    let v36 = v33 +. 1.0
                                    v36
                                }
                                False -> {
                                    let v37 = v34 <. 0.5
                                    case v37 {
                                        True -> {
                                            v33
                                        }
                                        False -> {
                                            let v38 = v33 /. 2.0
                                            let v39 = float.floor
                                            let v40 = v39( v38  )
                                            let v41 = v40 *. 2.0
                                            let v42 = v41 == v33
                                            case v42 {
                                                True -> {
                                                    v33
                                                }
                                                False -> {
                                                    let v43 = v33 +. 1.0
                                                    v43
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        let v47 = v46 == 3.0
                        let v48 = v47 != True
                        case v48 {
                            True -> {
                                4
                            }
                            False -> {
                                let v49 = float.floor
                                let v50 = v49( v2  )
                                let v51 = v2 -. v50
                                let v52 = v51 >. 0.5
                                let v63 =
                                    case v52 {
                                        True -> {
                                            let v53 = v50 +. 1.0
                                            v53
                                        }
                                        False -> {
                                            let v54 = v51 <. 0.5
                                            case v54 {
                                                True -> {
                                                    v50
                                                }
                                                False -> {
                                                    let v55 = v50 /. 2.0
                                                    let v56 = float.floor
                                                    let v57 = v56( v55  )
                                                    let v58 = v57 *. 2.0
                                                    let v59 = v58 == v50
                                                    case v59 {
                                                        True -> {
                                                            v50
                                                        }
                                                        False -> {
                                                            let v60 = v50 +. 1.0
                                                            v60
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                let v64 = v63 == -2.0
                                let v65 = v64 != True
                                case v65 {
                                    True -> {
                                        5
                                    }
                                    False -> {
                                        let v66 = float.floor
                                        let v67 = v66( v3  )
                                        let v68 = v3 -. v67
                                        let v69 = v68 >. 0.5
                                        let v80 =
                                            case v69 {
                                                True -> {
                                                    let v70 = v67 +. 1.0
                                                    v70
                                                }
                                                False -> {
                                                    let v71 = v68 <. 0.5
                                                    case v71 {
                                                        True -> {
                                                            v67
                                                        }
                                                        False -> {
                                                            let v72 = v67 /. 2.0
                                                            let v73 = float.floor
                                                            let v74 = v73( v72  )
                                                            let v75 = v74 *. 2.0
                                                            let v76 = v75 == v67
                                                            case v76 {
                                                                True -> {
                                                                    v67
                                                                }
                                                                False -> {
                                                                    let v77 = v67 +. 1.0
                                                                    v77
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        let v81 = v80 == 4.0
                                        let v82 = v81 != True
                                        case v82 {
                                            True -> {
                                                6
                                            }
                                            False -> {
                                                let v83 = float.floor
                                                let v84 = v83( v4  )
                                                let v85 = v4 -. v84
                                                let v86 = v85 >. 0.5
                                                let v97 =
                                                    case v86 {
                                                        True -> {
                                                            let v87 = v84 +. 1.0
                                                            v87
                                                        }
                                                        False -> {
                                                            let v88 = v85 <. 0.5
                                                            case v88 {
                                                                True -> {
                                                                    v84
                                                                }
                                                                False -> {
                                                                    let v89 = v84 /. 2.0
                                                                    let v90 = float.floor
                                                                    let v91 = v90( v89  )
                                                                    let v92 = v91 *. 2.0
                                                                    let v93 = v92 == v84
                                                                    case v93 {
                                                                        True -> {
                                                                            v84
                                                                        }
                                                                        False -> {
                                                                            let v94 = v84 +. 1.0
                                                                            v94
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                let v98 = v97 == 0.0
                                                let v99 = v98 != True
                                                case v99 {
                                                    True -> {
                                                        7
                                                    }
                                                    False -> {
                                                        let v100 = spiral_math_atan2(v5, v5)
                                                        let v101 = v100 *. 1000.0
                                                        let v102 = float.floor
                                                        let v103 = v102( v101  )
                                                        let v104 = v103 == 785.0
                                                        let v105 = v104 != True
                                                        case v105 {
                                                            True -> {
                                                                8
                                                            }
                                                            False -> {
                                                                let v106 = float.floor
                                                                let v107 = v106( v6  )
                                                                let v108 = v107 == 2.0
                                                                let v109 = v108 != True
                                                                case v109 {
                                                                    True -> {
                                                                        9
                                                                    }
                                                                    False -> {
                                                                        0
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
}
