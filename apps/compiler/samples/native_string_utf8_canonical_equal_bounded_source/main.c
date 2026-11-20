#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int refc;
    uint32_t len;
    char ptr[];
} Array0;
typedef Array0 String;
static inline void ArrayDecrefBody0(Array0 * x){
    (void)x;
}
static void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
static Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(char) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
static Array0 * ArrayLit0(uint32_t len, char * ptr){
    Array0 * x = ArrayCreate0(len, false);
    memcpy(x->ptr, ptr, sizeof(char) * len);
    return x;
}
static inline void StringDecref(String * x){
    return ArrayDecref0(x);
}
static inline String * StringLit(uint32_t len, char * ptr){
    return ArrayLit0(len, ptr);
}
static char runtime_byte2(String * v0, int32_t v1){
    char v2 = v0->ptr[v1];
    StringDecref(v0);
    return v2;
}
static int32_t utf8_scalar_at_byte_offset1(String * v0, int32_t v1){
    int32_t v2 = v0->len-1;
    bool v3 = v1 < 0l;
    if (v3){
        StringDecref(v0);
        fprintf(stderr, "%s\n", "UTF-8 byte offset is negative.");
        exit(EXIT_FAILURE);
    } else {
        bool v5 = v1 >= v2;
        if (v5){
            StringDecref(v0);
            fprintf(stderr, "%s\n", "UTF-8 byte offset is outside the string.");
            exit(EXIT_FAILURE);
        } else {
            (v0)->refc++;
            char v7 = runtime_byte2(v0, v1);
            int32_t v8 = ((uint8_t)v7);
            bool v9 = v8 < 128l;
            if (v9){
                StringDecref(v0);
                return v8;
            } else {
                bool v10 = v8 < 194l;
                if (v10){
                    StringDecref(v0);
                    fprintf(stderr, "%s\n", "UTF-8 scalar starts with an invalid lead byte.");
                    exit(EXIT_FAILURE);
                } else {
                    bool v12 = v8 < 224l;
                    if (v12){
                        int32_t v13 = v1 + 1l;
                        bool v14 = v13 >= v2;
                        if (v14){
                            StringDecref(v0);
                            fprintf(stderr, "%s\n", "UTF-8 sequence is truncated.");
                            exit(EXIT_FAILURE);
                        } else {
                            (v0)->refc++;
                            char v16 = runtime_byte2(v0, v13);
                            StringDecref(v0);
                            int32_t v17 = ((uint8_t)v16);
                            bool v18 = v17 < 128l;
                            bool v20;
                            if (v18){
                                v20 = false;
                            } else {
                                bool v19 = v17 < 192l;
                                v20 = v19;
                            }
                            if (v20){
                                int32_t v21 = v8 - 192l;
                                int32_t v22 = v21 * 64l;
                                int32_t v23 = v17 - 128l;
                                int32_t v24 = v22 + v23;
                                return v24;
                            } else {
                                fprintf(stderr, "%s\n", "UTF-8 sequence has an invalid continuation byte.");
                                exit(EXIT_FAILURE);
                            }
                        }
                    } else {
                        bool v28 = v8 < 240l;
                        if (v28){
                            int32_t v29 = v1 + 2l;
                            bool v30 = v29 >= v2;
                            if (v30){
                                StringDecref(v0);
                                fprintf(stderr, "%s\n", "UTF-8 sequence is truncated.");
                                exit(EXIT_FAILURE);
                            } else {
                                int32_t v32 = v1 + 1l;
                                (v0)->refc++;
                                char v33 = runtime_byte2(v0, v32);
                                int32_t v34 = ((uint8_t)v33);
                                (v0)->refc++;
                                char v35 = runtime_byte2(v0, v29);
                                StringDecref(v0);
                                int32_t v36 = ((uint8_t)v35);
                                bool v37 = v34 < 128l;
                                bool v39;
                                if (v37){
                                    v39 = false;
                                } else {
                                    bool v38 = v34 < 192l;
                                    v39 = v38;
                                }
                                if (v39){
                                    bool v40 = v36 < 128l;
                                    bool v42;
                                    if (v40){
                                        v42 = false;
                                    } else {
                                        bool v41 = v36 < 192l;
                                        v42 = v41;
                                    }
                                    if (v42){
                                        int32_t v43 = v8 - 224l;
                                        int32_t v44 = v43 * 4096l;
                                        int32_t v45 = v34 - 128l;
                                        int32_t v46 = v45 * 64l;
                                        int32_t v47 = v44 + v46;
                                        int32_t v48 = v36 - 128l;
                                        int32_t v49 = v47 + v48;
                                        bool v50 = v49 < 2048l;
                                        if (v50){
                                            fprintf(stderr, "%s\n", "UTF-8 sequence is overlong.");
                                            exit(EXIT_FAILURE);
                                        } else {
                                            bool v52 = v49 >= 55296l;
                                            if (v52){
                                                bool v53 = v49 <= 57343l;
                                                if (v53){
                                                    fprintf(stderr, "%s\n", "UTF-8 sequence encodes a surrogate.");
                                                    exit(EXIT_FAILURE);
                                                } else {
                                                    return v49;
                                                }
                                            } else {
                                                return v49;
                                            }
                                        }
                                    } else {
                                        fprintf(stderr, "%s\n", "UTF-8 sequence has an invalid continuation byte.");
                                        exit(EXIT_FAILURE);
                                    }
                                } else {
                                    fprintf(stderr, "%s\n", "UTF-8 sequence has an invalid continuation byte.");
                                    exit(EXIT_FAILURE);
                                }
                            }
                        } else {
                            bool v63 = v8 < 245l;
                            if (v63){
                                int32_t v64 = v1 + 3l;
                                bool v65 = v64 >= v2;
                                if (v65){
                                    StringDecref(v0);
                                    fprintf(stderr, "%s\n", "UTF-8 sequence is truncated.");
                                    exit(EXIT_FAILURE);
                                } else {
                                    int32_t v67 = v1 + 1l;
                                    (v0)->refc++;
                                    char v68 = runtime_byte2(v0, v67);
                                    int32_t v69 = ((uint8_t)v68);
                                    int32_t v70 = v1 + 2l;
                                    (v0)->refc++;
                                    char v71 = runtime_byte2(v0, v70);
                                    int32_t v72 = ((uint8_t)v71);
                                    (v0)->refc++;
                                    char v73 = runtime_byte2(v0, v64);
                                    StringDecref(v0);
                                    int32_t v74 = ((uint8_t)v73);
                                    bool v75 = v69 < 128l;
                                    bool v77;
                                    if (v75){
                                        v77 = false;
                                    } else {
                                        bool v76 = v69 < 192l;
                                        v77 = v76;
                                    }
                                    if (v77){
                                        bool v78 = v72 < 128l;
                                        bool v80;
                                        if (v78){
                                            v80 = false;
                                        } else {
                                            bool v79 = v72 < 192l;
                                            v80 = v79;
                                        }
                                        if (v80){
                                            bool v81 = v74 < 128l;
                                            bool v83;
                                            if (v81){
                                                v83 = false;
                                            } else {
                                                bool v82 = v74 < 192l;
                                                v83 = v82;
                                            }
                                            if (v83){
                                                int32_t v84 = v8 - 240l;
                                                int32_t v85 = v84 * 262144l;
                                                int32_t v86 = v69 - 128l;
                                                int32_t v87 = v86 * 4096l;
                                                int32_t v88 = v85 + v87;
                                                int32_t v89 = v72 - 128l;
                                                int32_t v90 = v89 * 64l;
                                                int32_t v91 = v88 + v90;
                                                int32_t v92 = v74 - 128l;
                                                int32_t v93 = v91 + v92;
                                                bool v94 = v93 < 65536l;
                                                if (v94){
                                                    fprintf(stderr, "%s\n", "UTF-8 sequence is overlong.");
                                                    exit(EXIT_FAILURE);
                                                } else {
                                                    bool v96 = v93 > 1114111l;
                                                    if (v96){
                                                        fprintf(stderr, "%s\n", "UTF-8 scalar is above U+10FFFF.");
                                                        exit(EXIT_FAILURE);
                                                    } else {
                                                        return v93;
                                                    }
                                                }
                                            } else {
                                                fprintf(stderr, "%s\n", "UTF-8 sequence has an invalid continuation byte.");
                                                exit(EXIT_FAILURE);
                                            }
                                        } else {
                                            fprintf(stderr, "%s\n", "UTF-8 sequence has an invalid continuation byte.");
                                            exit(EXIT_FAILURE);
                                        }
                                    } else {
                                        fprintf(stderr, "%s\n", "UTF-8 sequence has an invalid continuation byte.");
                                        exit(EXIT_FAILURE);
                                    }
                                }
                            } else {
                                StringDecref(v0);
                                fprintf(stderr, "%s\n", "UTF-8 scalar starts with an invalid lead byte.");
                                exit(EXIT_FAILURE);
                            }
                        }
                    }
                }
            }
        }
    }
}
static bool utf8_canonical_equal_bounded_loop0(String * v0, String * v1, int32_t v2, int32_t v3, int32_t v4, int32_t v5, int32_t v6, int32_t v7){
    while (1) {
        bool v8 = v4 >= 0l;
        int32_t v76; int32_t v77; int32_t v78;
        if (v8){
            v76 = v4; v77 = v2; v78 = -1l;
        } else {
            bool v9 = v2 == v6;
            if (v9){
                v76 = -1l; v77 = v2; v78 = -1l;
            } else {
                bool v10 = v2 > v6;
                if (v10){
                    fprintf(stderr, "%s\n", "UTF-8 canonical stream offset exceeds the string.");
                    exit(EXIT_FAILURE);
                } else {
                    (v0)->refc++;
                    int32_t v14 = utf8_scalar_at_byte_offset1(v0, v2);
                    bool v15 = v14 < 128l;
                    int32_t v20;
                    if (v15){
                        v20 = 1l;
                    } else {
                        bool v16 = v14 < 2048l;
                        if (v16){
                            v20 = 2l;
                        } else {
                            bool v17 = v14 < 65536l;
                            if (v17){
                                v20 = 3l;
                            } else {
                                v20 = 4l;
                            }
                        }
                    }
                    bool v21 = v14 == 192l;
                    int32_t v67; int32_t v68;
                    if (v21){
                        v67 = 65l; v68 = 768l;
                    } else {
                        bool v22 = v14 == 193l;
                        if (v22){
                            v67 = 65l; v68 = 769l;
                        } else {
                            bool v23 = v14 == 195l;
                            if (v23){
                                v67 = 65l; v68 = 771l;
                            } else {
                                bool v24 = v14 == 196l;
                                if (v24){
                                    v67 = 65l; v68 = 776l;
                                } else {
                                    bool v25 = v14 == 199l;
                                    if (v25){
                                        v67 = 67l; v68 = 807l;
                                    } else {
                                        bool v26 = v14 == 201l;
                                        if (v26){
                                            v67 = 69l; v68 = 769l;
                                        } else {
                                            bool v27 = v14 == 211l;
                                            if (v27){
                                                v67 = 79l; v68 = 769l;
                                            } else {
                                                bool v28 = v14 == 213l;
                                                if (v28){
                                                    v67 = 79l; v68 = 771l;
                                                } else {
                                                    bool v29 = v14 == 224l;
                                                    if (v29){
                                                        v67 = 97l; v68 = 768l;
                                                    } else {
                                                        bool v30 = v14 == 225l;
                                                        if (v30){
                                                            v67 = 97l; v68 = 769l;
                                                        } else {
                                                            bool v31 = v14 == 227l;
                                                            if (v31){
                                                                v67 = 97l; v68 = 771l;
                                                            } else {
                                                                bool v32 = v14 == 228l;
                                                                if (v32){
                                                                    v67 = 97l; v68 = 776l;
                                                                } else {
                                                                    bool v33 = v14 == 231l;
                                                                    if (v33){
                                                                        v67 = 99l; v68 = 807l;
                                                                    } else {
                                                                        bool v34 = v14 == 233l;
                                                                        if (v34){
                                                                            v67 = 101l; v68 = 769l;
                                                                        } else {
                                                                            bool v35 = v14 == 243l;
                                                                            if (v35){
                                                                                v67 = 111l; v68 = 769l;
                                                                            } else {
                                                                                bool v36 = v14 == 245l;
                                                                                if (v36){
                                                                                    v67 = 111l; v68 = 771l;
                                                                                } else {
                                                                                    v67 = v14; v68 = -1l;
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
                    int32_t v69 = v2 + v20;
                    v76 = v67; v77 = v69; v78 = v68;
                }
            }
        }
        bool v79 = v5 >= 0l;
        int32_t v147; int32_t v148; int32_t v149;
        if (v79){
            v147 = v5; v148 = v3; v149 = -1l;
        } else {
            bool v80 = v3 == v7;
            if (v80){
                v147 = -1l; v148 = v3; v149 = -1l;
            } else {
                bool v81 = v3 > v7;
                if (v81){
                    fprintf(stderr, "%s\n", "UTF-8 canonical stream offset exceeds the string.");
                    exit(EXIT_FAILURE);
                } else {
                    (v1)->refc++;
                    int32_t v85 = utf8_scalar_at_byte_offset1(v1, v3);
                    bool v86 = v85 < 128l;
                    int32_t v91;
                    if (v86){
                        v91 = 1l;
                    } else {
                        bool v87 = v85 < 2048l;
                        if (v87){
                            v91 = 2l;
                        } else {
                            bool v88 = v85 < 65536l;
                            if (v88){
                                v91 = 3l;
                            } else {
                                v91 = 4l;
                            }
                        }
                    }
                    bool v92 = v85 == 192l;
                    int32_t v138; int32_t v139;
                    if (v92){
                        v138 = 65l; v139 = 768l;
                    } else {
                        bool v93 = v85 == 193l;
                        if (v93){
                            v138 = 65l; v139 = 769l;
                        } else {
                            bool v94 = v85 == 195l;
                            if (v94){
                                v138 = 65l; v139 = 771l;
                            } else {
                                bool v95 = v85 == 196l;
                                if (v95){
                                    v138 = 65l; v139 = 776l;
                                } else {
                                    bool v96 = v85 == 199l;
                                    if (v96){
                                        v138 = 67l; v139 = 807l;
                                    } else {
                                        bool v97 = v85 == 201l;
                                        if (v97){
                                            v138 = 69l; v139 = 769l;
                                        } else {
                                            bool v98 = v85 == 211l;
                                            if (v98){
                                                v138 = 79l; v139 = 769l;
                                            } else {
                                                bool v99 = v85 == 213l;
                                                if (v99){
                                                    v138 = 79l; v139 = 771l;
                                                } else {
                                                    bool v100 = v85 == 224l;
                                                    if (v100){
                                                        v138 = 97l; v139 = 768l;
                                                    } else {
                                                        bool v101 = v85 == 225l;
                                                        if (v101){
                                                            v138 = 97l; v139 = 769l;
                                                        } else {
                                                            bool v102 = v85 == 227l;
                                                            if (v102){
                                                                v138 = 97l; v139 = 771l;
                                                            } else {
                                                                bool v103 = v85 == 228l;
                                                                if (v103){
                                                                    v138 = 97l; v139 = 776l;
                                                                } else {
                                                                    bool v104 = v85 == 231l;
                                                                    if (v104){
                                                                        v138 = 99l; v139 = 807l;
                                                                    } else {
                                                                        bool v105 = v85 == 233l;
                                                                        if (v105){
                                                                            v138 = 101l; v139 = 769l;
                                                                        } else {
                                                                            bool v106 = v85 == 243l;
                                                                            if (v106){
                                                                                v138 = 111l; v139 = 769l;
                                                                            } else {
                                                                                bool v107 = v85 == 245l;
                                                                                if (v107){
                                                                                    v138 = 111l; v139 = 771l;
                                                                                } else {
                                                                                    v138 = v85; v139 = -1l;
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
                    int32_t v140 = v3 + v91;
                    v147 = v138; v148 = v140; v149 = v139;
                }
            }
        }
        bool v150 = v76 < 0l;
        if (v150){
            StringDecref(v0); StringDecref(v1);
            bool v151 = v147 == -1l;
            return v151;
        } else {
            bool v152 = v147 < 0l;
            if (v152){
                StringDecref(v0); StringDecref(v1);
                return false;
            } else {
                bool v153 = v76 == v147;
                if (v153){
                    {
                        String * tmp0 = v0;
                        String * tmp1 = v1;
                        int32_t tmp2 = v77;
                        int32_t tmp3 = v148;
                        int32_t tmp4 = v78;
                        int32_t tmp5 = v149;
                        int32_t tmp6 = v6;
                        int32_t tmp7 = v7;
                        v0 = tmp0;
                        v1 = tmp1;
                        v2 = tmp2;
                        v3 = tmp3;
                        v4 = tmp4;
                        v5 = tmp5;
                        v6 = tmp6;
                        v7 = tmp7;
                    }
                    continue;
                } else {
                    StringDecref(v0); StringDecref(v1);
                    return false;
                }
            }
        }
    }
}
int32_t main(){
    String * v0 = StringLit(6, "plain");
    int32_t v1 = 0l;
    int32_t v2 = 0l;
    int32_t v3 = -1l;
    int32_t v4 = -1l;
    int32_t v5 = 5l;
    int32_t v6 = 5l;
    (v0)->refc += 2;
    bool v7 = utf8_canonical_equal_bounded_loop0(v0, v0, v1, v2, v3, v4, v5, v6);
    StringDecref(v0);
    String * v8 = StringLit(1, "");
    int32_t v9 = 0l;
    int32_t v10 = 0l;
    int32_t v11 = -1l;
    int32_t v12 = -1l;
    int32_t v13 = 0l;
    int32_t v14 = 0l;
    (v8)->refc += 2;
    bool v15 = utf8_canonical_equal_bounded_loop0(v8, v8, v9, v10, v11, v12, v13, v14);
    StringDecref(v8);
    String * v16 = StringLit(7, "éõç");
    String * v17 = StringLit(10, "éõç");
    int32_t v18 = 0l;
    int32_t v19 = 0l;
    int32_t v20 = -1l;
    int32_t v21 = -1l;
    int32_t v22 = 6l;
    int32_t v23 = 9l;
    (v16)->refc++; (v17)->refc++;
    bool v24 = utf8_canonical_equal_bounded_loop0(v16, v17, v18, v19, v20, v21, v22, v23);
    StringDecref(v16); StringDecref(v17);
    String * v25 = StringLit(5, "é̃");
    String * v26 = StringLit(6, "é̃");
    int32_t v27 = 0l;
    int32_t v28 = 0l;
    int32_t v29 = -1l;
    int32_t v30 = -1l;
    int32_t v31 = 4l;
    int32_t v32 = 5l;
    (v25)->refc++; (v26)->refc++;
    bool v33 = utf8_canonical_equal_bounded_loop0(v25, v26, v27, v28, v29, v30, v31, v32);
    StringDecref(v25);
    String * v34 = StringLit(3, "À");
    String * v35 = StringLit(4, "À");
    int32_t v36 = 0l;
    int32_t v37 = 0l;
    int32_t v38 = -1l;
    int32_t v39 = -1l;
    int32_t v40 = 2l;
    int32_t v41 = 3l;
    (v34)->refc++; (v35)->refc++;
    bool v42 = utf8_canonical_equal_bounded_loop0(v34, v35, v36, v37, v38, v39, v40, v41);
    StringDecref(v34); StringDecref(v35);
    String * v43 = StringLit(3, "Ω");
    int32_t v44 = 0l;
    int32_t v45 = 0l;
    int32_t v46 = -1l;
    int32_t v47 = -1l;
    int32_t v48 = 2l;
    int32_t v49 = 2l;
    (v43)->refc += 2;
    bool v50 = utf8_canonical_equal_bounded_loop0(v43, v43, v44, v45, v46, v47, v48, v49);
    String * v51 = StringLit(6, "ẽ́");
    int32_t v52 = 0l;
    int32_t v53 = 0l;
    int32_t v54 = -1l;
    int32_t v55 = -1l;
    int32_t v56 = 5l;
    int32_t v57 = 5l;
    (v26)->refc++; (v51)->refc++;
    bool v58 = utf8_canonical_equal_bounded_loop0(v26, v51, v52, v53, v54, v55, v56, v57);
    StringDecref(v26); StringDecref(v51);
    String * v59 = StringLit(3, "é");
    String * v60 = StringLit(3, "á");
    int32_t v61 = 0l;
    int32_t v62 = 0l;
    int32_t v63 = -1l;
    int32_t v64 = -1l;
    int32_t v65 = 2l;
    int32_t v66 = 2l;
    (v59)->refc++; (v60)->refc++;
    bool v67 = utf8_canonical_equal_bounded_loop0(v59, v60, v61, v62, v63, v64, v65, v66);
    StringDecref(v60);
    String * v68 = StringLit(3, "ω");
    int32_t v69 = 0l;
    int32_t v70 = 0l;
    int32_t v71 = -1l;
    int32_t v72 = -1l;
    int32_t v73 = 2l;
    int32_t v74 = 2l;
    (v43)->refc++; (v68)->refc++;
    bool v75 = utf8_canonical_equal_bounded_loop0(v43, v68, v69, v70, v71, v72, v73, v74);
    StringDecref(v43); StringDecref(v68);
    String * v76 = StringLit(2, "e");
    int32_t v77 = 0l;
    int32_t v78 = 0l;
    int32_t v79 = -1l;
    int32_t v80 = -1l;
    int32_t v81 = 2l;
    int32_t v82 = 1l;
    (v59)->refc++; (v76)->refc++;
    bool v83 = utf8_canonical_equal_bounded_loop0(v59, v76, v77, v78, v79, v80, v81, v82);
    StringDecref(v59); StringDecref(v76);
    if (v7){
        if (v15){
            if (v24){
                if (v33){
                    if (v42){
                        if (v50){
                            if (v58){
                                return 7l;
                            } else {
                                if (v67){
                                    return 8l;
                                } else {
                                    if (v75){
                                        return 9l;
                                    } else {
                                        if (v83){
                                            return 10l;
                                        } else {
                                            return 0l;
                                        }
                                    }
                                }
                            }
                        } else {
                            return 6l;
                        }
                    } else {
                        return 5l;
                    }
                } else {
                    return 4l;
                }
            } else {
                return 3l;
            }
        } else {
            return 2l;
        }
    } else {
        return 1l;
    }
}
