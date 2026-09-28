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
char runtime_byte1(String * v0, int32_t v1){
    
    
    char v2;
    v2 = v0->ptr[v1];
    
    StringDecref(v0);
    return v2;
}
int32_t utf8_scalar_at_byte_offset0(String * v0, int32_t v1){
    
    
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
            v7 = runtime_byte1(v0, v1);
            
            
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
                        v13 = v1 + 1l;
                        
                        
                        bool v14;
                        v14 = v13 >= v2;
                        
                        
                        if (v14){
                            
                            StringDecref(v0);
                            fprintf(stderr, "%s\n", "UTF-8 sequence is truncated.");
                            exit(EXIT_FAILURE);
                        } else {
                            v0->refc++;
                            
                            char v16;
                            v16 = runtime_byte1(v0, v13);
                            
                            StringDecref(v0);
                            int32_t v17;
                            v17 = ((uint8_t)v16);
                            
                            
                            bool v18;
                            v18 = v17 < 128l;
                            
                            
                            bool v20;
                            if (v18){
                                
                                
                                v20 = false;
                            } else {
                                
                                
                                bool v19;
                                v19 = v17 < 192l;
                                
                                
                                v20 = v19;
                            }
                            
                            
                            if (v20){
                                
                                
                                int32_t v21;
                                v21 = v8 - 192l;
                                
                                
                                int32_t v22;
                                v22 = v21 * 64l;
                                
                                
                                int32_t v23;
                                v23 = v17 - 128l;
                                
                                
                                int32_t v24;
                                v24 = v22 + v23;
                                
                                
                                return v24;
                            } else {
                                
                                
                                fprintf(stderr, "%s\n", "UTF-8 sequence has an invalid continuation byte.");
                                exit(EXIT_FAILURE);
                            }
                        }
                    } else {
                        
                        
                        bool v28;
                        v28 = v8 < 240l;
                        
                        
                        if (v28){
                            
                            
                            int32_t v29;
                            v29 = v1 + 2l;
                            
                            
                            bool v30;
                            v30 = v29 >= v2;
                            
                            
                            if (v30){
                                
                                StringDecref(v0);
                                fprintf(stderr, "%s\n", "UTF-8 sequence is truncated.");
                                exit(EXIT_FAILURE);
                            } else {
                                
                                
                                int32_t v32;
                                v32 = v1 + 1l;
                                v0->refc++;
                                
                                char v33;
                                v33 = runtime_byte1(v0, v32);
                                
                                
                                int32_t v34;
                                v34 = ((uint8_t)v33);
                                v0->refc++;
                                
                                char v35;
                                v35 = runtime_byte1(v0, v29);
                                
                                StringDecref(v0);
                                int32_t v36;
                                v36 = ((uint8_t)v35);
                                
                                
                                bool v37;
                                v37 = v34 < 128l;
                                
                                
                                bool v39;
                                if (v37){
                                    
                                    
                                    v39 = false;
                                } else {
                                    
                                    
                                    bool v38;
                                    v38 = v34 < 192l;
                                    
                                    
                                    v39 = v38;
                                }
                                
                                
                                if (v39){
                                    
                                    
                                    bool v40;
                                    v40 = v36 < 128l;
                                    
                                    
                                    bool v42;
                                    if (v40){
                                        
                                        
                                        v42 = false;
                                    } else {
                                        
                                        
                                        bool v41;
                                        v41 = v36 < 192l;
                                        
                                        
                                        v42 = v41;
                                    }
                                    
                                    
                                    if (v42){
                                        
                                        
                                        int32_t v43;
                                        v43 = v8 - 224l;
                                        
                                        
                                        int32_t v44;
                                        v44 = v43 * 4096l;
                                        
                                        
                                        int32_t v45;
                                        v45 = v34 - 128l;
                                        
                                        
                                        int32_t v46;
                                        v46 = v45 * 64l;
                                        
                                        
                                        int32_t v47;
                                        v47 = v44 + v46;
                                        
                                        
                                        int32_t v48;
                                        v48 = v36 - 128l;
                                        
                                        
                                        int32_t v49;
                                        v49 = v47 + v48;
                                        
                                        
                                        bool v50;
                                        v50 = v49 < 2048l;
                                        
                                        
                                        if (v50){
                                            
                                            
                                            fprintf(stderr, "%s\n", "UTF-8 sequence is overlong.");
                                            exit(EXIT_FAILURE);
                                        } else {
                                            
                                            
                                            bool v52;
                                            v52 = v49 >= 55296l;
                                            
                                            
                                            if (v52){
                                                
                                                
                                                bool v53;
                                                v53 = v49 <= 57343l;
                                                
                                                
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
                            
                            
                            bool v63;
                            v63 = v8 < 245l;
                            
                            
                            if (v63){
                                
                                
                                int32_t v64;
                                v64 = v1 + 3l;
                                
                                
                                bool v65;
                                v65 = v64 >= v2;
                                
                                
                                if (v65){
                                    
                                    StringDecref(v0);
                                    fprintf(stderr, "%s\n", "UTF-8 sequence is truncated.");
                                    exit(EXIT_FAILURE);
                                } else {
                                    
                                    
                                    int32_t v67;
                                    v67 = v1 + 1l;
                                    v0->refc++;
                                    
                                    char v68;
                                    v68 = runtime_byte1(v0, v67);
                                    
                                    
                                    int32_t v69;
                                    v69 = ((uint8_t)v68);
                                    
                                    
                                    int32_t v70;
                                    v70 = v1 + 2l;
                                    v0->refc++;
                                    
                                    char v71;
                                    v71 = runtime_byte1(v0, v70);
                                    
                                    
                                    int32_t v72;
                                    v72 = ((uint8_t)v71);
                                    v0->refc++;
                                    
                                    char v73;
                                    v73 = runtime_byte1(v0, v64);
                                    
                                    StringDecref(v0);
                                    int32_t v74;
                                    v74 = ((uint8_t)v73);
                                    
                                    
                                    bool v75;
                                    v75 = v69 < 128l;
                                    
                                    
                                    bool v77;
                                    if (v75){
                                        
                                        
                                        v77 = false;
                                    } else {
                                        
                                        
                                        bool v76;
                                        v76 = v69 < 192l;
                                        
                                        
                                        v77 = v76;
                                    }
                                    
                                    
                                    if (v77){
                                        
                                        
                                        bool v78;
                                        v78 = v72 < 128l;
                                        
                                        
                                        bool v80;
                                        if (v78){
                                            
                                            
                                            v80 = false;
                                        } else {
                                            
                                            
                                            bool v79;
                                            v79 = v72 < 192l;
                                            
                                            
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
                                                
                                                
                                                int32_t v84;
                                                v84 = v8 - 240l;
                                                
                                                
                                                int32_t v85;
                                                v85 = v84 * 262144l;
                                                
                                                
                                                int32_t v86;
                                                v86 = v69 - 128l;
                                                
                                                
                                                int32_t v87;
                                                v87 = v86 * 4096l;
                                                
                                                
                                                int32_t v88;
                                                v88 = v85 + v87;
                                                
                                                
                                                int32_t v89;
                                                v89 = v72 - 128l;
                                                
                                                
                                                int32_t v90;
                                                v90 = v89 * 64l;
                                                
                                                
                                                int32_t v91;
                                                v91 = v88 + v90;
                                                
                                                
                                                int32_t v92;
                                                v92 = v74 - 128l;
                                                
                                                
                                                int32_t v93;
                                                v93 = v91 + v92;
                                                
                                                
                                                bool v94;
                                                v94 = v93 < 65536l;
                                                
                                                
                                                if (v94){
                                                    
                                                    
                                                    fprintf(stderr, "%s\n", "UTF-8 sequence is overlong.");
                                                    exit(EXIT_FAILURE);
                                                } else {
                                                    
                                                    
                                                    bool v96;
                                                    v96 = v93 > 1114111l;
                                                    
                                                    
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
int32_t main(){
    
    
    String * v0;
    v0 = StringLit(3, "é");
    
    
    int32_t v1;
    v1 = 0l;
    v0->refc++;
    
    int32_t v2;
    v2 = utf8_scalar_at_byte_offset0(v0, v1);
    
    StringDecref(v0);
    String * v3;
    v3 = StringLit(3, "õ");
    
    
    int32_t v4;
    v4 = 0l;
    v3->refc++;
    
    int32_t v5;
    v5 = utf8_scalar_at_byte_offset0(v3, v4);
    
    StringDecref(v3);
    String * v6;
    v6 = StringLit(3, "ç");
    
    
    int32_t v7;
    v7 = 0l;
    v6->refc++;
    
    int32_t v8;
    v8 = utf8_scalar_at_byte_offset0(v6, v7);
    
    StringDecref(v6);
    String * v9;
    v9 = StringLit(3, "́");
    
    
    int32_t v10;
    v10 = 0l;
    v9->refc++;
    
    int32_t v11;
    v11 = utf8_scalar_at_byte_offset0(v9, v10);
    
    StringDecref(v9);
    String * v12;
    v12 = StringLit(3, "̃");
    
    
    int32_t v13;
    v13 = 0l;
    v12->refc++;
    
    int32_t v14;
    v14 = utf8_scalar_at_byte_offset0(v12, v13);
    
    StringDecref(v12);
    String * v15;
    v15 = StringLit(3, "̧");
    
    
    int32_t v16;
    v16 = 0l;
    v15->refc++;
    
    int32_t v17;
    v17 = utf8_scalar_at_byte_offset0(v15, v16);
    
    StringDecref(v15);
    bool v18;
    v18 = v2 == 192l;
    
    
    int32_t v64; int32_t v65;
    if (v18){
        
        
        v64 = 65l; v65 = 768l;
    } else {
        
        
        bool v19;
        v19 = v2 == 193l;
        
        
        if (v19){
            
            
            v64 = 65l; v65 = 769l;
        } else {
            
            
            bool v20;
            v20 = v2 == 195l;
            
            
            if (v20){
                
                
                v64 = 65l; v65 = 771l;
            } else {
                
                
                bool v21;
                v21 = v2 == 196l;
                
                
                if (v21){
                    
                    
                    v64 = 65l; v65 = 776l;
                } else {
                    
                    
                    bool v22;
                    v22 = v2 == 199l;
                    
                    
                    if (v22){
                        
                        
                        v64 = 67l; v65 = 807l;
                    } else {
                        
                        
                        bool v23;
                        v23 = v2 == 201l;
                        
                        
                        if (v23){
                            
                            
                            v64 = 69l; v65 = 769l;
                        } else {
                            
                            
                            bool v24;
                            v24 = v2 == 211l;
                            
                            
                            if (v24){
                                
                                
                                v64 = 79l; v65 = 769l;
                            } else {
                                
                                
                                bool v25;
                                v25 = v2 == 213l;
                                
                                
                                if (v25){
                                    
                                    
                                    v64 = 79l; v65 = 771l;
                                } else {
                                    
                                    
                                    bool v26;
                                    v26 = v2 == 224l;
                                    
                                    
                                    if (v26){
                                        
                                        
                                        v64 = 97l; v65 = 768l;
                                    } else {
                                        
                                        
                                        bool v27;
                                        v27 = v2 == 225l;
                                        
                                        
                                        if (v27){
                                            
                                            
                                            v64 = 97l; v65 = 769l;
                                        } else {
                                            
                                            
                                            bool v28;
                                            v28 = v2 == 227l;
                                            
                                            
                                            if (v28){
                                                
                                                
                                                v64 = 97l; v65 = 771l;
                                            } else {
                                                
                                                
                                                bool v29;
                                                v29 = v2 == 228l;
                                                
                                                
                                                if (v29){
                                                    
                                                    
                                                    v64 = 97l; v65 = 776l;
                                                } else {
                                                    
                                                    
                                                    bool v30;
                                                    v30 = v2 == 231l;
                                                    
                                                    
                                                    if (v30){
                                                        
                                                        
                                                        v64 = 99l; v65 = 807l;
                                                    } else {
                                                        
                                                        
                                                        bool v31;
                                                        v31 = v2 == 233l;
                                                        
                                                        
                                                        if (v31){
                                                            
                                                            
                                                            v64 = 101l; v65 = 769l;
                                                        } else {
                                                            
                                                            
                                                            bool v32;
                                                            v32 = v2 == 243l;
                                                            
                                                            
                                                            if (v32){
                                                                
                                                                
                                                                v64 = 111l; v65 = 769l;
                                                            } else {
                                                                
                                                                
                                                                bool v33;
                                                                v33 = v2 == 245l;
                                                                
                                                                
                                                                if (v33){
                                                                    
                                                                    
                                                                    v64 = 111l; v65 = 771l;
                                                                } else {
                                                                    
                                                                    
                                                                    v64 = v2; v65 = -1l;
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
    
    
    bool v66;
    v66 = v5 == 192l;
    
    
    int32_t v112; int32_t v113;
    if (v66){
        
        
        v112 = 65l; v113 = 768l;
    } else {
        
        
        bool v67;
        v67 = v5 == 193l;
        
        
        if (v67){
            
            
            v112 = 65l; v113 = 769l;
        } else {
            
            
            bool v68;
            v68 = v5 == 195l;
            
            
            if (v68){
                
                
                v112 = 65l; v113 = 771l;
            } else {
                
                
                bool v69;
                v69 = v5 == 196l;
                
                
                if (v69){
                    
                    
                    v112 = 65l; v113 = 776l;
                } else {
                    
                    
                    bool v70;
                    v70 = v5 == 199l;
                    
                    
                    if (v70){
                        
                        
                        v112 = 67l; v113 = 807l;
                    } else {
                        
                        
                        bool v71;
                        v71 = v5 == 201l;
                        
                        
                        if (v71){
                            
                            
                            v112 = 69l; v113 = 769l;
                        } else {
                            
                            
                            bool v72;
                            v72 = v5 == 211l;
                            
                            
                            if (v72){
                                
                                
                                v112 = 79l; v113 = 769l;
                            } else {
                                
                                
                                bool v73;
                                v73 = v5 == 213l;
                                
                                
                                if (v73){
                                    
                                    
                                    v112 = 79l; v113 = 771l;
                                } else {
                                    
                                    
                                    bool v74;
                                    v74 = v5 == 224l;
                                    
                                    
                                    if (v74){
                                        
                                        
                                        v112 = 97l; v113 = 768l;
                                    } else {
                                        
                                        
                                        bool v75;
                                        v75 = v5 == 225l;
                                        
                                        
                                        if (v75){
                                            
                                            
                                            v112 = 97l; v113 = 769l;
                                        } else {
                                            
                                            
                                            bool v76;
                                            v76 = v5 == 227l;
                                            
                                            
                                            if (v76){
                                                
                                                
                                                v112 = 97l; v113 = 771l;
                                            } else {
                                                
                                                
                                                bool v77;
                                                v77 = v5 == 228l;
                                                
                                                
                                                if (v77){
                                                    
                                                    
                                                    v112 = 97l; v113 = 776l;
                                                } else {
                                                    
                                                    
                                                    bool v78;
                                                    v78 = v5 == 231l;
                                                    
                                                    
                                                    if (v78){
                                                        
                                                        
                                                        v112 = 99l; v113 = 807l;
                                                    } else {
                                                        
                                                        
                                                        bool v79;
                                                        v79 = v5 == 233l;
                                                        
                                                        
                                                        if (v79){
                                                            
                                                            
                                                            v112 = 101l; v113 = 769l;
                                                        } else {
                                                            
                                                            
                                                            bool v80;
                                                            v80 = v5 == 243l;
                                                            
                                                            
                                                            if (v80){
                                                                
                                                                
                                                                v112 = 111l; v113 = 769l;
                                                            } else {
                                                                
                                                                
                                                                bool v81;
                                                                v81 = v5 == 245l;
                                                                
                                                                
                                                                if (v81){
                                                                    
                                                                    
                                                                    v112 = 111l; v113 = 771l;
                                                                } else {
                                                                    
                                                                    
                                                                    v112 = v5; v113 = -1l;
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
    
    
    bool v114;
    v114 = v8 == 192l;
    
    
    int32_t v160; int32_t v161;
    if (v114){
        
        
        v160 = 65l; v161 = 768l;
    } else {
        
        
        bool v115;
        v115 = v8 == 193l;
        
        
        if (v115){
            
            
            v160 = 65l; v161 = 769l;
        } else {
            
            
            bool v116;
            v116 = v8 == 195l;
            
            
            if (v116){
                
                
                v160 = 65l; v161 = 771l;
            } else {
                
                
                bool v117;
                v117 = v8 == 196l;
                
                
                if (v117){
                    
                    
                    v160 = 65l; v161 = 776l;
                } else {
                    
                    
                    bool v118;
                    v118 = v8 == 199l;
                    
                    
                    if (v118){
                        
                        
                        v160 = 67l; v161 = 807l;
                    } else {
                        
                        
                        bool v119;
                        v119 = v8 == 201l;
                        
                        
                        if (v119){
                            
                            
                            v160 = 69l; v161 = 769l;
                        } else {
                            
                            
                            bool v120;
                            v120 = v8 == 211l;
                            
                            
                            if (v120){
                                
                                
                                v160 = 79l; v161 = 769l;
                            } else {
                                
                                
                                bool v121;
                                v121 = v8 == 213l;
                                
                                
                                if (v121){
                                    
                                    
                                    v160 = 79l; v161 = 771l;
                                } else {
                                    
                                    
                                    bool v122;
                                    v122 = v8 == 224l;
                                    
                                    
                                    if (v122){
                                        
                                        
                                        v160 = 97l; v161 = 768l;
                                    } else {
                                        
                                        
                                        bool v123;
                                        v123 = v8 == 225l;
                                        
                                        
                                        if (v123){
                                            
                                            
                                            v160 = 97l; v161 = 769l;
                                        } else {
                                            
                                            
                                            bool v124;
                                            v124 = v8 == 227l;
                                            
                                            
                                            if (v124){
                                                
                                                
                                                v160 = 97l; v161 = 771l;
                                            } else {
                                                
                                                
                                                bool v125;
                                                v125 = v8 == 228l;
                                                
                                                
                                                if (v125){
                                                    
                                                    
                                                    v160 = 97l; v161 = 776l;
                                                } else {
                                                    
                                                    
                                                    bool v126;
                                                    v126 = v8 == 231l;
                                                    
                                                    
                                                    if (v126){
                                                        
                                                        
                                                        v160 = 99l; v161 = 807l;
                                                    } else {
                                                        
                                                        
                                                        bool v127;
                                                        v127 = v8 == 233l;
                                                        
                                                        
                                                        if (v127){
                                                            
                                                            
                                                            v160 = 101l; v161 = 769l;
                                                        } else {
                                                            
                                                            
                                                            bool v128;
                                                            v128 = v8 == 243l;
                                                            
                                                            
                                                            if (v128){
                                                                
                                                                
                                                                v160 = 111l; v161 = 769l;
                                                            } else {
                                                                
                                                                
                                                                bool v129;
                                                                v129 = v8 == 245l;
                                                                
                                                                
                                                                if (v129){
                                                                    
                                                                    
                                                                    v160 = 111l; v161 = 771l;
                                                                } else {
                                                                    
                                                                    
                                                                    v160 = v8; v161 = -1l;
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
    
    
    bool v162;
    v162 = v11 == 769l;
    
    
    int32_t v163;
    if (v162){
        
        
        v163 = 233l;
    } else {
        
        
        v163 = -1l;
    }
    
    
    bool v164;
    v164 = v163 < 0l;
    
    
    int32_t v165; int32_t v166;
    if (v164){
        
        
        v165 = 101l; v166 = v11;
    } else {
        
        
        v165 = v163; v166 = -1l;
    }
    
    
    bool v167;
    v167 = v14 == 769l;
    
    
    int32_t v170;
    if (v167){
        
        
        v170 = 243l;
    } else {
        
        
        bool v168;
        v168 = v14 == 771l;
        
        
        if (v168){
            
            
            v170 = 245l;
        } else {
            
            
            v170 = -1l;
        }
    }
    
    
    bool v171;
    v171 = v170 < 0l;
    
    
    int32_t v172; int32_t v173;
    if (v171){
        
        
        v172 = 111l; v173 = v14;
    } else {
        
        
        v172 = v170; v173 = -1l;
    }
    
    
    bool v174;
    v174 = v17 == 807l;
    
    
    int32_t v175;
    if (v174){
        
        
        v175 = 231l;
    } else {
        
        
        v175 = -1l;
    }
    
    
    bool v176;
    v176 = v175 < 0l;
    
    
    int32_t v177; int32_t v178;
    if (v176){
        
        
        v177 = 99l; v178 = v17;
    } else {
        
        
        v177 = v175; v178 = -1l;
    }
    
    
    bool v179;
    v179 = v64 == 101l;
    
    
    bool v181;
    if (v179){
        
        
        bool v180;
        v180 = v65 == v11;
        
        
        v181 = v180;
    } else {
        
        
        v181 = false;
    }
    
    
    if (v181){
        
        
        bool v182;
        v182 = v112 == 111l;
        
        
        bool v184;
        if (v182){
            
            
            bool v183;
            v183 = v113 == v14;
            
            
            v184 = v183;
        } else {
            
            
            v184 = false;
        }
        
        
        if (v184){
            
            
            bool v185;
            v185 = v160 == 99l;
            
            
            bool v187;
            if (v185){
                
                
                bool v186;
                v186 = v161 == v17;
                
                
                v187 = v186;
            } else {
                
                
                v187 = false;
            }
            
            
            if (v187){
                
                
                bool v188;
                v188 = v165 == v2;
                
                
                bool v190;
                if (v188){
                    
                    
                    bool v189;
                    v189 = v166 == -1l;
                    
                    
                    v190 = v189;
                } else {
                    
                    
                    v190 = false;
                }
                
                
                if (v190){
                    
                    
                    bool v191;
                    v191 = v172 == v5;
                    
                    
                    bool v193;
                    if (v191){
                        
                        
                        bool v192;
                        v192 = v173 == -1l;
                        
                        
                        v193 = v192;
                    } else {
                        
                        
                        v193 = false;
                    }
                    
                    
                    if (v193){
                        
                        
                        bool v194;
                        v194 = v177 == v8;
                        
                        
                        bool v196;
                        if (v194){
                            
                            
                            bool v195;
                            v195 = v178 == -1l;
                            
                            
                            v196 = v195;
                        } else {
                            
                            
                            v196 = false;
                        }
                        
                        
                        if (v196){
                            
                            
                            return 0l;
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
