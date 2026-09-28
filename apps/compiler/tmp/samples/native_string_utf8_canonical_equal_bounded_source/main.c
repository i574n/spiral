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
}
void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(char) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array0 * ArrayLit0(uint32_t len, char * ptr){
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
char runtime_byte2(String * v0, int32_t v1){
    
    
    char v2;
    v2 = v0->ptr[v1];
    
    StringDecref(v0);
    return v2;
}
int32_t utf8_scalar_at_byte_offset1(String * v0, int32_t v1){
    
    
    int32_t v2;
    v2 = v0->len-1;
    
    
    bool v3;
    v3 = v1 < 0l;
    
    
    if (v3){
        
        StringDecref(v0);
        fprintf(stderr, "%s\n", "UTF-8 byte offset is negative.");
        exit(EXIT_FAILURE);
    } else {
        
        
        bool v5;
        v5 = v1 >= v2;
        
        
        if (v5){
            
            StringDecref(v0);
            fprintf(stderr, "%s\n", "UTF-8 byte offset is outside the string.");
            exit(EXIT_FAILURE);
        } else {
            v0->refc++;
            
            char v7;
            v7 = runtime_byte2(v0, v1);
            
            
            int32_t v8;
            v8 = ((uint8_t)v7);
            
            
            bool v9;
            v9 = v8 < 128l;
            
            
            if (v9){
                
                StringDecref(v0);
                return v8;
            } else {
                
                
                bool v10;
                v10 = v8 < 194l;
                
                
                if (v10){
                    
                    StringDecref(v0);
                    fprintf(stderr, "%s\n", "UTF-8 scalar starts with an invalid lead byte.");
                    exit(EXIT_FAILURE);
                } else {
                    
                    
                    bool v12;
                    v12 = v8 < 224l;
                    
                    
                    if (v12){
                        
                        
                        int32_t v13;
                        v13 = v1 + 1l ;
                        
                        
                        bool v14;
                        v14 = v13 >= v2;
                        
                        
                        if (v14){
                            
                            StringDecref(v0);
                            fprintf(stderr, "%s\n", "UTF-8 sequence is truncated.");
                            exit(EXIT_FAILURE);
                        } else {
                            
                            
                            int32_t v16;
                            v16 = v1 + 1l ;
                            v0->refc++;
                            
                            char v17;
                            v17 = runtime_byte2(v0, v16);
                            
                            StringDecref(v0);
                            int32_t v18;
                            v18 = ((uint8_t)v17);
                            
                            
                            bool v19;
                            v19 = v18 < 128l;
                            
                            
                            bool v21;
                            if (v19){
                                
                                
                                v21 = false;
                            } else {
                                
                                
                                bool v20;
                                v20 = v18 < 192l;
                                
                                
                                v21 = v20;
                            }
                            
                            
                            if (v21){
                                
                                
                                int32_t v22;
                                v22 = v8 - 192l ;
                                
                                
                                int32_t v23;
                                v23 = v22 * 64l ;
                                
                                
                                int32_t v24;
                                v24 = v18 - 128l ;
                                
                                
                                int32_t v25;
                                v25 = v23 + v24 ;
                                
                                
                                return v25;
                            } else {
                                
                                
                                fprintf(stderr, "%s\n", "UTF-8 sequence has an invalid continuation byte.");
                                exit(EXIT_FAILURE);
                            }
                        }
                    } else {
                        
                        
                        bool v29;
                        v29 = v8 < 240l;
                        
                        
                        if (v29){
                            
                            
                            int32_t v30;
                            v30 = v1 + 2l ;
                            
                            
                            bool v31;
                            v31 = v30 >= v2;
                            
                            
                            if (v31){
                                
                                StringDecref(v0);
                                fprintf(stderr, "%s\n", "UTF-8 sequence is truncated.");
                                exit(EXIT_FAILURE);
                            } else {
                                
                                
                                int32_t v33;
                                v33 = v1 + 1l ;
                                v0->refc++;
                                
                                char v34;
                                v34 = runtime_byte2(v0, v33);
                                
                                
                                int32_t v35;
                                v35 = ((uint8_t)v34);
                                
                                
                                int32_t v36;
                                v36 = v1 + 2l ;
                                v0->refc++;
                                
                                char v37;
                                v37 = runtime_byte2(v0, v36);
                                
                                StringDecref(v0);
                                int32_t v38;
                                v38 = ((uint8_t)v37);
                                
                                
                                bool v39;
                                v39 = v35 < 128l;
                                
                                
                                bool v41;
                                if (v39){
                                    
                                    
                                    v41 = false;
                                } else {
                                    
                                    
                                    bool v40;
                                    v40 = v35 < 192l;
                                    
                                    
                                    v41 = v40;
                                }
                                
                                
                                if (v41){
                                    
                                    
                                    bool v42;
                                    v42 = v38 < 128l;
                                    
                                    
                                    bool v44;
                                    if (v42){
                                        
                                        
                                        v44 = false;
                                    } else {
                                        
                                        
                                        bool v43;
                                        v43 = v38 < 192l;
                                        
                                        
                                        v44 = v43;
                                    }
                                    
                                    
                                    if (v44){
                                        
                                        
                                        int32_t v45;
                                        v45 = v8 - 224l ;
                                        
                                        
                                        int32_t v46;
                                        v46 = v45 * 4096l ;
                                        
                                        
                                        int32_t v47;
                                        v47 = v35 - 128l ;
                                        
                                        
                                        int32_t v48;
                                        v48 = v47 * 64l ;
                                        
                                        
                                        int32_t v49;
                                        v49 = v46 + v48 ;
                                        
                                        
                                        int32_t v50;
                                        v50 = v38 - 128l ;
                                        
                                        
                                        int32_t v51;
                                        v51 = v49 + v50 ;
                                        
                                        
                                        bool v52;
                                        v52 = v51 < 2048l;
                                        
                                        
                                        if (v52){
                                            
                                            
                                            fprintf(stderr, "%s\n", "UTF-8 sequence is overlong.");
                                            exit(EXIT_FAILURE);
                                        } else {
                                            
                                            
                                            bool v54;
                                            v54 = v51 >= 55296l;
                                            
                                            
                                            if (v54){
                                                
                                                
                                                bool v55;
                                                v55 = v51 <= 57343l;
                                                
                                                
                                                if (v55){
                                                    
                                                    
                                                    fprintf(stderr, "%s\n", "UTF-8 sequence encodes a surrogate.");
                                                    exit(EXIT_FAILURE);
                                                } else {
                                                    
                                                    
                                                    return v51;
                                                }
                                            } else {
                                                
                                                
                                                return v51;
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
                            
                            
                            bool v65;
                            v65 = v8 < 245l;
                            
                            
                            if (v65){
                                
                                
                                int32_t v66;
                                v66 = v1 + 3l ;
                                
                                
                                bool v67;
                                v67 = v66 >= v2;
                                
                                
                                if (v67){
                                    
                                    StringDecref(v0);
                                    fprintf(stderr, "%s\n", "UTF-8 sequence is truncated.");
                                    exit(EXIT_FAILURE);
                                } else {
                                    
                                    
                                    int32_t v69;
                                    v69 = v1 + 1l ;
                                    v0->refc++;
                                    
                                    char v70;
                                    v70 = runtime_byte2(v0, v69);
                                    
                                    
                                    int32_t v71;
                                    v71 = ((uint8_t)v70);
                                    
                                    
                                    int32_t v72;
                                    v72 = v1 + 2l ;
                                    v0->refc++;
                                    
                                    char v73;
                                    v73 = runtime_byte2(v0, v72);
                                    
                                    
                                    int32_t v74;
                                    v74 = ((uint8_t)v73);
                                    
                                    
                                    int32_t v75;
                                    v75 = v1 + 3l ;
                                    v0->refc++;
                                    
                                    char v76;
                                    v76 = runtime_byte2(v0, v75);
                                    
                                    StringDecref(v0);
                                    int32_t v77;
                                    v77 = ((uint8_t)v76);
                                    
                                    
                                    bool v78;
                                    v78 = v71 < 128l;
                                    
                                    
                                    bool v80;
                                    if (v78){
                                        
                                        
                                        v80 = false;
                                    } else {
                                        
                                        
                                        bool v79;
                                        v79 = v71 < 192l;
                                        
                                        
                                        v80 = v79;
                                    }
                                    
                                    
                                    if (v80){
                                        
                                        
                                        bool v81;
                                        v81 = v74 < 128l;
                                        
                                        
                                        bool v83;
                                        if (v81){
                                            
                                            
                                            v83 = false;
                                        } else {
                                            
                                            
                                            bool v82;
                                            v82 = v74 < 192l;
                                            
                                            
                                            v83 = v82;
                                        }
                                        
                                        
                                        if (v83){
                                            
                                            
                                            bool v84;
                                            v84 = v77 < 128l;
                                            
                                            
                                            bool v86;
                                            if (v84){
                                                
                                                
                                                v86 = false;
                                            } else {
                                                
                                                
                                                bool v85;
                                                v85 = v77 < 192l;
                                                
                                                
                                                v86 = v85;
                                            }
                                            
                                            
                                            if (v86){
                                                
                                                
                                                int32_t v87;
                                                v87 = v8 - 240l ;
                                                
                                                
                                                int32_t v88;
                                                v88 = v87 * 262144l ;
                                                
                                                
                                                int32_t v89;
                                                v89 = v71 - 128l ;
                                                
                                                
                                                int32_t v90;
                                                v90 = v89 * 4096l ;
                                                
                                                
                                                int32_t v91;
                                                v91 = v88 + v90 ;
                                                
                                                
                                                int32_t v92;
                                                v92 = v74 - 128l ;
                                                
                                                
                                                int32_t v93;
                                                v93 = v92 * 64l ;
                                                
                                                
                                                int32_t v94;
                                                v94 = v91 + v93 ;
                                                
                                                
                                                int32_t v95;
                                                v95 = v77 - 128l ;
                                                
                                                
                                                int32_t v96;
                                                v96 = v94 + v95 ;
                                                
                                                
                                                bool v97;
                                                v97 = v96 < 65536l;
                                                
                                                
                                                if (v97){
                                                    
                                                    
                                                    fprintf(stderr, "%s\n", "UTF-8 sequence is overlong.");
                                                    exit(EXIT_FAILURE);
                                                } else {
                                                    
                                                    
                                                    bool v99;
                                                    v99 = v96 > 1114111l;
                                                    
                                                    
                                                    if (v99){
                                                        
                                                        
                                                        fprintf(stderr, "%s\n", "UTF-8 scalar is above U+10FFFF.");
                                                        exit(EXIT_FAILURE);
                                                    } else {
                                                        
                                                        
                                                        return v96;
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
bool utf8_canonical_equal_bounded_loop0(String * v0, int32_t v1, int32_t v2, int32_t v3, int32_t v4, int32_t v5, int32_t v6){
    
    
    bool v7;
    v7 = v3 >= 0l;
    
    
    int32_t v75; int32_t v76; int32_t v77;
    if (v7){
        
        
        v75 = v3; v76 = v1; v77 = -1l;
    } else {
        
        
        bool v8;
        v8 = v1 == v5 ;
        
        
        if (v8){
            
            
            v75 = -1l; v76 = v1; v77 = -1l;
        } else {
            
            
            bool v9;
            v9 = v1 > v5;
            
            
            if (v9){
                
                
                fprintf(stderr, "%s\n", "UTF-8 canonical stream offset exceeds the string.");
                exit(EXIT_FAILURE);
            } else {
                v0->refc++;
                
                int32_t v13;
                v13 = utf8_scalar_at_byte_offset1(v0, v1);
                
                
                bool v14;
                v14 = v13 < 128l;
                
                
                int32_t v19;
                if (v14){
                    
                    
                    v19 = 1l;
                } else {
                    
                    
                    bool v15;
                    v15 = v13 < 2048l;
                    
                    
                    if (v15){
                        
                        
                        v19 = 2l;
                    } else {
                        
                        
                        bool v16;
                        v16 = v13 < 65536l;
                        
                        
                        if (v16){
                            
                            
                            v19 = 3l;
                        } else {
                            
                            
                            v19 = 4l;
                        }
                    }
                }
                
                
                bool v20;
                v20 = v13 == 192l ;
                
                
                int32_t v66; int32_t v67;
                if (v20){
                    
                    
                    v66 = 65l; v67 = 768l;
                } else {
                    
                    
                    bool v21;
                    v21 = v13 == 193l ;
                    
                    
                    if (v21){
                        
                        
                        v66 = 65l; v67 = 769l;
                    } else {
                        
                        
                        bool v22;
                        v22 = v13 == 195l ;
                        
                        
                        if (v22){
                            
                            
                            v66 = 65l; v67 = 771l;
                        } else {
                            
                            
                            bool v23;
                            v23 = v13 == 196l ;
                            
                            
                            if (v23){
                                
                                
                                v66 = 65l; v67 = 776l;
                            } else {
                                
                                
                                bool v24;
                                v24 = v13 == 199l ;
                                
                                
                                if (v24){
                                    
                                    
                                    v66 = 67l; v67 = 807l;
                                } else {
                                    
                                    
                                    bool v25;
                                    v25 = v13 == 201l ;
                                    
                                    
                                    if (v25){
                                        
                                        
                                        v66 = 69l; v67 = 769l;
                                    } else {
                                        
                                        
                                        bool v26;
                                        v26 = v13 == 211l ;
                                        
                                        
                                        if (v26){
                                            
                                            
                                            v66 = 79l; v67 = 769l;
                                        } else {
                                            
                                            
                                            bool v27;
                                            v27 = v13 == 213l ;
                                            
                                            
                                            if (v27){
                                                
                                                
                                                v66 = 79l; v67 = 771l;
                                            } else {
                                                
                                                
                                                bool v28;
                                                v28 = v13 == 224l ;
                                                
                                                
                                                if (v28){
                                                    
                                                    
                                                    v66 = 97l; v67 = 768l;
                                                } else {
                                                    
                                                    
                                                    bool v29;
                                                    v29 = v13 == 225l ;
                                                    
                                                    
                                                    if (v29){
                                                        
                                                        
                                                        v66 = 97l; v67 = 769l;
                                                    } else {
                                                        
                                                        
                                                        bool v30;
                                                        v30 = v13 == 227l ;
                                                        
                                                        
                                                        if (v30){
                                                            
                                                            
                                                            v66 = 97l; v67 = 771l;
                                                        } else {
                                                            
                                                            
                                                            bool v31;
                                                            v31 = v13 == 228l ;
                                                            
                                                            
                                                            if (v31){
                                                                
                                                                
                                                                v66 = 97l; v67 = 776l;
                                                            } else {
                                                                
                                                                
                                                                bool v32;
                                                                v32 = v13 == 231l ;
                                                                
                                                                
                                                                if (v32){
                                                                    
                                                                    
                                                                    v66 = 99l; v67 = 807l;
                                                                } else {
                                                                    
                                                                    
                                                                    bool v33;
                                                                    v33 = v13 == 233l ;
                                                                    
                                                                    
                                                                    if (v33){
                                                                        
                                                                        
                                                                        v66 = 101l; v67 = 769l;
                                                                    } else {
                                                                        
                                                                        
                                                                        bool v34;
                                                                        v34 = v13 == 243l ;
                                                                        
                                                                        
                                                                        if (v34){
                                                                            
                                                                            
                                                                            v66 = 111l; v67 = 769l;
                                                                        } else {
                                                                            
                                                                            
                                                                            bool v35;
                                                                            v35 = v13 == 245l ;
                                                                            
                                                                            
                                                                            if (v35){
                                                                                
                                                                                
                                                                                v66 = 111l; v67 = 771l;
                                                                            } else {
                                                                                
                                                                                
                                                                                v66 = v13; v67 = -1l;
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
                
                
                int32_t v68;
                v68 = v1 + v19 ;
                
                
                v75 = v66; v76 = v68; v77 = v67;
            }
        }
    }
    
    
    bool v78;
    v78 = v4 >= 0l;
    
    
    int32_t v146; int32_t v147; int32_t v148;
    if (v78){
        
        
        v146 = v4; v147 = v2; v148 = -1l;
    } else {
        
        
        bool v79;
        v79 = v2 == v6 ;
        
        
        if (v79){
            
            
            v146 = -1l; v147 = v2; v148 = -1l;
        } else {
            
            
            bool v80;
            v80 = v2 > v6;
            
            
            if (v80){
                
                
                fprintf(stderr, "%s\n", "UTF-8 canonical stream offset exceeds the string.");
                exit(EXIT_FAILURE);
            } else {
                v0->refc++;
                
                int32_t v84;
                v84 = utf8_scalar_at_byte_offset1(v0, v2);
                
                
                bool v85;
                v85 = v84 < 128l;
                
                
                int32_t v90;
                if (v85){
                    
                    
                    v90 = 1l;
                } else {
                    
                    
                    bool v86;
                    v86 = v84 < 2048l;
                    
                    
                    if (v86){
                        
                        
                        v90 = 2l;
                    } else {
                        
                        
                        bool v87;
                        v87 = v84 < 65536l;
                        
                        
                        if (v87){
                            
                            
                            v90 = 3l;
                        } else {
                            
                            
                            v90 = 4l;
                        }
                    }
                }
                
                
                bool v91;
                v91 = v84 == 192l ;
                
                
                int32_t v137; int32_t v138;
                if (v91){
                    
                    
                    v137 = 65l; v138 = 768l;
                } else {
                    
                    
                    bool v92;
                    v92 = v84 == 193l ;
                    
                    
                    if (v92){
                        
                        
                        v137 = 65l; v138 = 769l;
                    } else {
                        
                        
                        bool v93;
                        v93 = v84 == 195l ;
                        
                        
                        if (v93){
                            
                            
                            v137 = 65l; v138 = 771l;
                        } else {
                            
                            
                            bool v94;
                            v94 = v84 == 196l ;
                            
                            
                            if (v94){
                                
                                
                                v137 = 65l; v138 = 776l;
                            } else {
                                
                                
                                bool v95;
                                v95 = v84 == 199l ;
                                
                                
                                if (v95){
                                    
                                    
                                    v137 = 67l; v138 = 807l;
                                } else {
                                    
                                    
                                    bool v96;
                                    v96 = v84 == 201l ;
                                    
                                    
                                    if (v96){
                                        
                                        
                                        v137 = 69l; v138 = 769l;
                                    } else {
                                        
                                        
                                        bool v97;
                                        v97 = v84 == 211l ;
                                        
                                        
                                        if (v97){
                                            
                                            
                                            v137 = 79l; v138 = 769l;
                                        } else {
                                            
                                            
                                            bool v98;
                                            v98 = v84 == 213l ;
                                            
                                            
                                            if (v98){
                                                
                                                
                                                v137 = 79l; v138 = 771l;
                                            } else {
                                                
                                                
                                                bool v99;
                                                v99 = v84 == 224l ;
                                                
                                                
                                                if (v99){
                                                    
                                                    
                                                    v137 = 97l; v138 = 768l;
                                                } else {
                                                    
                                                    
                                                    bool v100;
                                                    v100 = v84 == 225l ;
                                                    
                                                    
                                                    if (v100){
                                                        
                                                        
                                                        v137 = 97l; v138 = 769l;
                                                    } else {
                                                        
                                                        
                                                        bool v101;
                                                        v101 = v84 == 227l ;
                                                        
                                                        
                                                        if (v101){
                                                            
                                                            
                                                            v137 = 97l; v138 = 771l;
                                                        } else {
                                                            
                                                            
                                                            bool v102;
                                                            v102 = v84 == 228l ;
                                                            
                                                            
                                                            if (v102){
                                                                
                                                                
                                                                v137 = 97l; v138 = 776l;
                                                            } else {
                                                                
                                                                
                                                                bool v103;
                                                                v103 = v84 == 231l ;
                                                                
                                                                
                                                                if (v103){
                                                                    
                                                                    
                                                                    v137 = 99l; v138 = 807l;
                                                                } else {
                                                                    
                                                                    
                                                                    bool v104;
                                                                    v104 = v84 == 233l ;
                                                                    
                                                                    
                                                                    if (v104){
                                                                        
                                                                        
                                                                        v137 = 101l; v138 = 769l;
                                                                    } else {
                                                                        
                                                                        
                                                                        bool v105;
                                                                        v105 = v84 == 243l ;
                                                                        
                                                                        
                                                                        if (v105){
                                                                            
                                                                            
                                                                            v137 = 111l; v138 = 769l;
                                                                        } else {
                                                                            
                                                                            
                                                                            bool v106;
                                                                            v106 = v84 == 245l ;
                                                                            
                                                                            
                                                                            if (v106){
                                                                                
                                                                                
                                                                                v137 = 111l; v138 = 771l;
                                                                            } else {
                                                                                
                                                                                
                                                                                v137 = v84; v138 = -1l;
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
                
                
                int32_t v139;
                v139 = v2 + v90 ;
                
                
                v146 = v137; v147 = v139; v148 = v138;
            }
        }
    }
    
    
    bool v149;
    v149 = v75 < 0l;
    
    
    if (v149){
        
        StringDecref(v0);
        bool v150;
        v150 = v146 == -1l ;
        
        
        return v150;
    } else {
        
        
        bool v151;
        v151 = v146 < 0l;
        
        
        if (v151){
            
            StringDecref(v0);
            return false;
        } else {
            
            
            bool v152;
            v152 = v75 == v146 ;
            
            
            if (v152){
                
                
                return utf8_canonical_equal_bounded_loop0(v0, v76, v147, v77, v148, v5, v6);
            } else {
                
                StringDecref(v0);
                return false;
            }
        }
    }
}
bool utf8_canonical_equal_bounded_loop3(String * v0, String * v1, int32_t v2, int32_t v3, int32_t v4, int32_t v5, int32_t v6, int32_t v7){
    
    
    bool v8;
    v8 = v4 >= 0l;
    
    
    int32_t v76; int32_t v77; int32_t v78;
    if (v8){
        
        
        v76 = v4; v77 = v2; v78 = -1l;
    } else {
        
        
        bool v9;
        v9 = v2 == v6 ;
        
        
        if (v9){
            
            
            v76 = -1l; v77 = v2; v78 = -1l;
        } else {
            
            
            bool v10;
            v10 = v2 > v6;
            
            
            if (v10){
                
                
                fprintf(stderr, "%s\n", "UTF-8 canonical stream offset exceeds the string.");
                exit(EXIT_FAILURE);
            } else {
                v0->refc++;
                
                int32_t v14;
                v14 = utf8_scalar_at_byte_offset1(v0, v2);
                
                
                bool v15;
                v15 = v14 < 128l;
                
                
                int32_t v20;
                if (v15){
                    
                    
                    v20 = 1l;
                } else {
                    
                    
                    bool v16;
                    v16 = v14 < 2048l;
                    
                    
                    if (v16){
                        
                        
                        v20 = 2l;
                    } else {
                        
                        
                        bool v17;
                        v17 = v14 < 65536l;
                        
                        
                        if (v17){
                            
                            
                            v20 = 3l;
                        } else {
                            
                            
                            v20 = 4l;
                        }
                    }
                }
                
                
                bool v21;
                v21 = v14 == 192l ;
                
                
                int32_t v67; int32_t v68;
                if (v21){
                    
                    
                    v67 = 65l; v68 = 768l;
                } else {
                    
                    
                    bool v22;
                    v22 = v14 == 193l ;
                    
                    
                    if (v22){
                        
                        
                        v67 = 65l; v68 = 769l;
                    } else {
                        
                        
                        bool v23;
                        v23 = v14 == 195l ;
                        
                        
                        if (v23){
                            
                            
                            v67 = 65l; v68 = 771l;
                        } else {
                            
                            
                            bool v24;
                            v24 = v14 == 196l ;
                            
                            
                            if (v24){
                                
                                
                                v67 = 65l; v68 = 776l;
                            } else {
                                
                                
                                bool v25;
                                v25 = v14 == 199l ;
                                
                                
                                if (v25){
                                    
                                    
                                    v67 = 67l; v68 = 807l;
                                } else {
                                    
                                    
                                    bool v26;
                                    v26 = v14 == 201l ;
                                    
                                    
                                    if (v26){
                                        
                                        
                                        v67 = 69l; v68 = 769l;
                                    } else {
                                        
                                        
                                        bool v27;
                                        v27 = v14 == 211l ;
                                        
                                        
                                        if (v27){
                                            
                                            
                                            v67 = 79l; v68 = 769l;
                                        } else {
                                            
                                            
                                            bool v28;
                                            v28 = v14 == 213l ;
                                            
                                            
                                            if (v28){
                                                
                                                
                                                v67 = 79l; v68 = 771l;
                                            } else {
                                                
                                                
                                                bool v29;
                                                v29 = v14 == 224l ;
                                                
                                                
                                                if (v29){
                                                    
                                                    
                                                    v67 = 97l; v68 = 768l;
                                                } else {
                                                    
                                                    
                                                    bool v30;
                                                    v30 = v14 == 225l ;
                                                    
                                                    
                                                    if (v30){
                                                        
                                                        
                                                        v67 = 97l; v68 = 769l;
                                                    } else {
                                                        
                                                        
                                                        bool v31;
                                                        v31 = v14 == 227l ;
                                                        
                                                        
                                                        if (v31){
                                                            
                                                            
                                                            v67 = 97l; v68 = 771l;
                                                        } else {
                                                            
                                                            
                                                            bool v32;
                                                            v32 = v14 == 228l ;
                                                            
                                                            
                                                            if (v32){
                                                                
                                                                
                                                                v67 = 97l; v68 = 776l;
                                                            } else {
                                                                
                                                                
                                                                bool v33;
                                                                v33 = v14 == 231l ;
                                                                
                                                                
                                                                if (v33){
                                                                    
                                                                    
                                                                    v67 = 99l; v68 = 807l;
                                                                } else {
                                                                    
                                                                    
                                                                    bool v34;
                                                                    v34 = v14 == 233l ;
                                                                    
                                                                    
                                                                    if (v34){
                                                                        
                                                                        
                                                                        v67 = 101l; v68 = 769l;
                                                                    } else {
                                                                        
                                                                        
                                                                        bool v35;
                                                                        v35 = v14 == 243l ;
                                                                        
                                                                        
                                                                        if (v35){
                                                                            
                                                                            
                                                                            v67 = 111l; v68 = 769l;
                                                                        } else {
                                                                            
                                                                            
                                                                            bool v36;
                                                                            v36 = v14 == 245l ;
                                                                            
                                                                            
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
                
                
                int32_t v69;
                v69 = v2 + v20 ;
                
                
                v76 = v67; v77 = v69; v78 = v68;
            }
        }
    }
    
    
    bool v79;
    v79 = v5 >= 0l;
    
    
    int32_t v147; int32_t v148; int32_t v149;
    if (v79){
        
        
        v147 = v5; v148 = v3; v149 = -1l;
    } else {
        
        
        bool v80;
        v80 = v3 == v7 ;
        
        
        if (v80){
            
            
            v147 = -1l; v148 = v3; v149 = -1l;
        } else {
            
            
            bool v81;
            v81 = v3 > v7;
            
            
            if (v81){
                
                
                fprintf(stderr, "%s\n", "UTF-8 canonical stream offset exceeds the string.");
                exit(EXIT_FAILURE);
            } else {
                v1->refc++;
                
                int32_t v85;
                v85 = utf8_scalar_at_byte_offset1(v1, v3);
                
                
                bool v86;
                v86 = v85 < 128l;
                
                
                int32_t v91;
                if (v86){
                    
                    
                    v91 = 1l;
                } else {
                    
                    
                    bool v87;
                    v87 = v85 < 2048l;
                    
                    
                    if (v87){
                        
                        
                        v91 = 2l;
                    } else {
                        
                        
                        bool v88;
                        v88 = v85 < 65536l;
                        
                        
                        if (v88){
                            
                            
                            v91 = 3l;
                        } else {
                            
                            
                            v91 = 4l;
                        }
                    }
                }
                
                
                bool v92;
                v92 = v85 == 192l ;
                
                
                int32_t v138; int32_t v139;
                if (v92){
                    
                    
                    v138 = 65l; v139 = 768l;
                } else {
                    
                    
                    bool v93;
                    v93 = v85 == 193l ;
                    
                    
                    if (v93){
                        
                        
                        v138 = 65l; v139 = 769l;
                    } else {
                        
                        
                        bool v94;
                        v94 = v85 == 195l ;
                        
                        
                        if (v94){
                            
                            
                            v138 = 65l; v139 = 771l;
                        } else {
                            
                            
                            bool v95;
                            v95 = v85 == 196l ;
                            
                            
                            if (v95){
                                
                                
                                v138 = 65l; v139 = 776l;
                            } else {
                                
                                
                                bool v96;
                                v96 = v85 == 199l ;
                                
                                
                                if (v96){
                                    
                                    
                                    v138 = 67l; v139 = 807l;
                                } else {
                                    
                                    
                                    bool v97;
                                    v97 = v85 == 201l ;
                                    
                                    
                                    if (v97){
                                        
                                        
                                        v138 = 69l; v139 = 769l;
                                    } else {
                                        
                                        
                                        bool v98;
                                        v98 = v85 == 211l ;
                                        
                                        
                                        if (v98){
                                            
                                            
                                            v138 = 79l; v139 = 769l;
                                        } else {
                                            
                                            
                                            bool v99;
                                            v99 = v85 == 213l ;
                                            
                                            
                                            if (v99){
                                                
                                                
                                                v138 = 79l; v139 = 771l;
                                            } else {
                                                
                                                
                                                bool v100;
                                                v100 = v85 == 224l ;
                                                
                                                
                                                if (v100){
                                                    
                                                    
                                                    v138 = 97l; v139 = 768l;
                                                } else {
                                                    
                                                    
                                                    bool v101;
                                                    v101 = v85 == 225l ;
                                                    
                                                    
                                                    if (v101){
                                                        
                                                        
                                                        v138 = 97l; v139 = 769l;
                                                    } else {
                                                        
                                                        
                                                        bool v102;
                                                        v102 = v85 == 227l ;
                                                        
                                                        
                                                        if (v102){
                                                            
                                                            
                                                            v138 = 97l; v139 = 771l;
                                                        } else {
                                                            
                                                            
                                                            bool v103;
                                                            v103 = v85 == 228l ;
                                                            
                                                            
                                                            if (v103){
                                                                
                                                                
                                                                v138 = 97l; v139 = 776l;
                                                            } else {
                                                                
                                                                
                                                                bool v104;
                                                                v104 = v85 == 231l ;
                                                                
                                                                
                                                                if (v104){
                                                                    
                                                                    
                                                                    v138 = 99l; v139 = 807l;
                                                                } else {
                                                                    
                                                                    
                                                                    bool v105;
                                                                    v105 = v85 == 233l ;
                                                                    
                                                                    
                                                                    if (v105){
                                                                        
                                                                        
                                                                        v138 = 101l; v139 = 769l;
                                                                    } else {
                                                                        
                                                                        
                                                                        bool v106;
                                                                        v106 = v85 == 243l ;
                                                                        
                                                                        
                                                                        if (v106){
                                                                            
                                                                            
                                                                            v138 = 111l; v139 = 769l;
                                                                        } else {
                                                                            
                                                                            
                                                                            bool v107;
                                                                            v107 = v85 == 245l ;
                                                                            
                                                                            
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
                
                
                int32_t v140;
                v140 = v3 + v91 ;
                
                
                v147 = v138; v148 = v140; v149 = v139;
            }
        }
    }
    
    
    bool v150;
    v150 = v76 < 0l;
    
    
    if (v150){
        
        StringDecref(v0); StringDecref(v1);
        bool v151;
        v151 = v147 == -1l ;
        
        
        return v151;
    } else {
        
        
        bool v152;
        v152 = v147 < 0l;
        
        
        if (v152){
            
            StringDecref(v0); StringDecref(v1);
            return false;
        } else {
            
            
            bool v153;
            v153 = v76 == v147 ;
            
            
            if (v153){
                
                
                return utf8_canonical_equal_bounded_loop3(v0, v1, v77, v148, v78, v149, v6, v7);
            } else {
                
                StringDecref(v0); StringDecref(v1);
                return false;
            }
        }
    }
}
int32_t main(){
    
    
    String * v0;
    v0 = StringLit(6, "plain");
    
    
    int32_t v1;
    v1 = 0l;
    
    
    int32_t v2;
    v2 = 0l;
    
    
    int32_t v3;
    v3 = -1l;
    
    
    int32_t v4;
    v4 = -1l;
    
    
    int32_t v5;
    v5 = 5l;
    
    
    int32_t v6;
    v6 = 5l;
    v0->refc++;
    
    bool v7;
    v7 = utf8_canonical_equal_bounded_loop0(v0, v1, v2, v3, v4, v5, v6);
    
    StringDecref(v0);
    String * v8;
    v8 = StringLit(1, "");
    
    
    int32_t v9;
    v9 = 0l;
    
    
    int32_t v10;
    v10 = 0l;
    
    
    int32_t v11;
    v11 = -1l;
    
    
    int32_t v12;
    v12 = -1l;
    
    
    int32_t v13;
    v13 = 0l;
    
    
    int32_t v14;
    v14 = 0l;
    v8->refc++;
    
    bool v15;
    v15 = utf8_canonical_equal_bounded_loop0(v8, v9, v10, v11, v12, v13, v14);
    
    StringDecref(v8);
    String * v16;
    v16 = StringLit(7, "éõç");
    
    
    String * v17;
    v17 = StringLit(10, "éõç");
    
    
    int32_t v18;
    v18 = 0l;
    
    
    int32_t v19;
    v19 = 0l;
    
    
    int32_t v20;
    v20 = -1l;
    
    
    int32_t v21;
    v21 = -1l;
    
    
    int32_t v22;
    v22 = 6l;
    
    
    int32_t v23;
    v23 = 9l;
    v16->refc++; v17->refc++;
    
    bool v24;
    v24 = utf8_canonical_equal_bounded_loop3(v16, v17, v18, v19, v20, v21, v22, v23);
    
    StringDecref(v16); StringDecref(v17);
    String * v25;
    v25 = StringLit(5, "é̃");
    
    
    String * v26;
    v26 = StringLit(6, "é̃");
    
    
    int32_t v27;
    v27 = 0l;
    
    
    int32_t v28;
    v28 = 0l;
    
    
    int32_t v29;
    v29 = -1l;
    
    
    int32_t v30;
    v30 = -1l;
    
    
    int32_t v31;
    v31 = 4l;
    
    
    int32_t v32;
    v32 = 5l;
    v25->refc++; v26->refc++;
    
    bool v33;
    v33 = utf8_canonical_equal_bounded_loop3(v25, v26, v27, v28, v29, v30, v31, v32);
    
    StringDecref(v25);
    String * v34;
    v34 = StringLit(3, "À");
    
    
    String * v35;
    v35 = StringLit(4, "À");
    
    
    int32_t v36;
    v36 = 0l;
    
    
    int32_t v37;
    v37 = 0l;
    
    
    int32_t v38;
    v38 = -1l;
    
    
    int32_t v39;
    v39 = -1l;
    
    
    int32_t v40;
    v40 = 2l;
    
    
    int32_t v41;
    v41 = 3l;
    v34->refc++; v35->refc++;
    
    bool v42;
    v42 = utf8_canonical_equal_bounded_loop3(v34, v35, v36, v37, v38, v39, v40, v41);
    
    StringDecref(v34); StringDecref(v35);
    String * v43;
    v43 = StringLit(3, "Ω");
    
    
    int32_t v44;
    v44 = 0l;
    
    
    int32_t v45;
    v45 = 0l;
    
    
    int32_t v46;
    v46 = -1l;
    
    
    int32_t v47;
    v47 = -1l;
    
    
    int32_t v48;
    v48 = 2l;
    
    
    int32_t v49;
    v49 = 2l;
    v43->refc++;
    
    bool v50;
    v50 = utf8_canonical_equal_bounded_loop0(v43, v44, v45, v46, v47, v48, v49);
    
    
    String * v51;
    v51 = StringLit(6, "ẽ́");
    
    
    int32_t v52;
    v52 = 0l;
    
    
    int32_t v53;
    v53 = 0l;
    
    
    int32_t v54;
    v54 = -1l;
    
    
    int32_t v55;
    v55 = -1l;
    
    
    int32_t v56;
    v56 = 5l;
    
    
    int32_t v57;
    v57 = 5l;
    v26->refc++; v51->refc++;
    
    bool v58;
    v58 = utf8_canonical_equal_bounded_loop3(v26, v51, v52, v53, v54, v55, v56, v57);
    
    StringDecref(v26); StringDecref(v51);
    String * v59;
    v59 = StringLit(3, "é");
    
    
    String * v60;
    v60 = StringLit(3, "á");
    
    
    int32_t v61;
    v61 = 0l;
    
    
    int32_t v62;
    v62 = 0l;
    
    
    int32_t v63;
    v63 = -1l;
    
    
    int32_t v64;
    v64 = -1l;
    
    
    int32_t v65;
    v65 = 2l;
    
    
    int32_t v66;
    v66 = 2l;
    v59->refc++; v60->refc++;
    
    bool v67;
    v67 = utf8_canonical_equal_bounded_loop3(v59, v60, v61, v62, v63, v64, v65, v66);
    
    StringDecref(v60);
    String * v68;
    v68 = StringLit(3, "ω");
    
    
    int32_t v69;
    v69 = 0l;
    
    
    int32_t v70;
    v70 = 0l;
    
    
    int32_t v71;
    v71 = -1l;
    
    
    int32_t v72;
    v72 = -1l;
    
    
    int32_t v73;
    v73 = 2l;
    
    
    int32_t v74;
    v74 = 2l;
    v43->refc++; v68->refc++;
    
    bool v75;
    v75 = utf8_canonical_equal_bounded_loop3(v43, v68, v69, v70, v71, v72, v73, v74);
    
    StringDecref(v43); StringDecref(v68);
    String * v76;
    v76 = StringLit(2, "e");
    
    
    int32_t v77;
    v77 = 0l;
    
    
    int32_t v78;
    v78 = 0l;
    
    
    int32_t v79;
    v79 = -1l;
    
    
    int32_t v80;
    v80 = -1l;
    
    
    int32_t v81;
    v81 = 2l;
    
    
    int32_t v82;
    v82 = 1l;
    v59->refc++; v76->refc++;
    
    bool v83;
    v83 = utf8_canonical_equal_bounded_loop3(v59, v76, v77, v78, v79, v80, v81, v82);
    
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
