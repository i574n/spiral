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
                            v17 = runtime_byte1(v0, v16);
                            
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
                                v34 = runtime_byte1(v0, v33);
                                
                                
                                int32_t v35;
                                v35 = ((uint8_t)v34);
                                
                                
                                int32_t v36;
                                v36 = v1 + 2l ;
                                v0->refc++;
                                
                                char v37;
                                v37 = runtime_byte1(v0, v36);
                                
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
                                    v70 = runtime_byte1(v0, v69);
                                    
                                    
                                    int32_t v71;
                                    v71 = ((uint8_t)v70);
                                    
                                    
                                    int32_t v72;
                                    v72 = v1 + 2l ;
                                    v0->refc++;
                                    
                                    char v73;
                                    v73 = runtime_byte1(v0, v72);
                                    
                                    
                                    int32_t v74;
                                    v74 = ((uint8_t)v73);
                                    
                                    
                                    int32_t v75;
                                    v75 = v1 + 3l ;
                                    v0->refc++;
                                    
                                    char v76;
                                    v76 = runtime_byte1(v0, v75);
                                    
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
    v18 = v2 == 192l ;
    
    
    int32_t v64; int32_t v65;
    if (v18){
        
        
        v64 = 65l; v65 = 768l;
    } else {
        
        
        bool v19;
        v19 = v2 == 193l ;
        
        
        if (v19){
            
            
            v64 = 65l; v65 = 769l;
        } else {
            
            
            bool v20;
            v20 = v2 == 195l ;
            
            
            if (v20){
                
                
                v64 = 65l; v65 = 771l;
            } else {
                
                
                bool v21;
                v21 = v2 == 196l ;
                
                
                if (v21){
                    
                    
                    v64 = 65l; v65 = 776l;
                } else {
                    
                    
                    bool v22;
                    v22 = v2 == 199l ;
                    
                    
                    if (v22){
                        
                        
                        v64 = 67l; v65 = 807l;
                    } else {
                        
                        
                        bool v23;
                        v23 = v2 == 201l ;
                        
                        
                        if (v23){
                            
                            
                            v64 = 69l; v65 = 769l;
                        } else {
                            
                            
                            bool v24;
                            v24 = v2 == 211l ;
                            
                            
                            if (v24){
                                
                                
                                v64 = 79l; v65 = 769l;
                            } else {
                                
                                
                                bool v25;
                                v25 = v2 == 213l ;
                                
                                
                                if (v25){
                                    
                                    
                                    v64 = 79l; v65 = 771l;
                                } else {
                                    
                                    
                                    bool v26;
                                    v26 = v2 == 224l ;
                                    
                                    
                                    if (v26){
                                        
                                        
                                        v64 = 97l; v65 = 768l;
                                    } else {
                                        
                                        
                                        bool v27;
                                        v27 = v2 == 225l ;
                                        
                                        
                                        if (v27){
                                            
                                            
                                            v64 = 97l; v65 = 769l;
                                        } else {
                                            
                                            
                                            bool v28;
                                            v28 = v2 == 227l ;
                                            
                                            
                                            if (v28){
                                                
                                                
                                                v64 = 97l; v65 = 771l;
                                            } else {
                                                
                                                
                                                bool v29;
                                                v29 = v2 == 228l ;
                                                
                                                
                                                if (v29){
                                                    
                                                    
                                                    v64 = 97l; v65 = 776l;
                                                } else {
                                                    
                                                    
                                                    bool v30;
                                                    v30 = v2 == 231l ;
                                                    
                                                    
                                                    if (v30){
                                                        
                                                        
                                                        v64 = 99l; v65 = 807l;
                                                    } else {
                                                        
                                                        
                                                        bool v31;
                                                        v31 = v2 == 233l ;
                                                        
                                                        
                                                        if (v31){
                                                            
                                                            
                                                            v64 = 101l; v65 = 769l;
                                                        } else {
                                                            
                                                            
                                                            bool v32;
                                                            v32 = v2 == 243l ;
                                                            
                                                            
                                                            if (v32){
                                                                
                                                                
                                                                v64 = 111l; v65 = 769l;
                                                            } else {
                                                                
                                                                
                                                                bool v33;
                                                                v33 = v2 == 245l ;
                                                                
                                                                
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
    v66 = v5 == 192l ;
    
    
    int32_t v112; int32_t v113;
    if (v66){
        
        
        v112 = 65l; v113 = 768l;
    } else {
        
        
        bool v67;
        v67 = v5 == 193l ;
        
        
        if (v67){
            
            
            v112 = 65l; v113 = 769l;
        } else {
            
            
            bool v68;
            v68 = v5 == 195l ;
            
            
            if (v68){
                
                
                v112 = 65l; v113 = 771l;
            } else {
                
                
                bool v69;
                v69 = v5 == 196l ;
                
                
                if (v69){
                    
                    
                    v112 = 65l; v113 = 776l;
                } else {
                    
                    
                    bool v70;
                    v70 = v5 == 199l ;
                    
                    
                    if (v70){
                        
                        
                        v112 = 67l; v113 = 807l;
                    } else {
                        
                        
                        bool v71;
                        v71 = v5 == 201l ;
                        
                        
                        if (v71){
                            
                            
                            v112 = 69l; v113 = 769l;
                        } else {
                            
                            
                            bool v72;
                            v72 = v5 == 211l ;
                            
                            
                            if (v72){
                                
                                
                                v112 = 79l; v113 = 769l;
                            } else {
                                
                                
                                bool v73;
                                v73 = v5 == 213l ;
                                
                                
                                if (v73){
                                    
                                    
                                    v112 = 79l; v113 = 771l;
                                } else {
                                    
                                    
                                    bool v74;
                                    v74 = v5 == 224l ;
                                    
                                    
                                    if (v74){
                                        
                                        
                                        v112 = 97l; v113 = 768l;
                                    } else {
                                        
                                        
                                        bool v75;
                                        v75 = v5 == 225l ;
                                        
                                        
                                        if (v75){
                                            
                                            
                                            v112 = 97l; v113 = 769l;
                                        } else {
                                            
                                            
                                            bool v76;
                                            v76 = v5 == 227l ;
                                            
                                            
                                            if (v76){
                                                
                                                
                                                v112 = 97l; v113 = 771l;
                                            } else {
                                                
                                                
                                                bool v77;
                                                v77 = v5 == 228l ;
                                                
                                                
                                                if (v77){
                                                    
                                                    
                                                    v112 = 97l; v113 = 776l;
                                                } else {
                                                    
                                                    
                                                    bool v78;
                                                    v78 = v5 == 231l ;
                                                    
                                                    
                                                    if (v78){
                                                        
                                                        
                                                        v112 = 99l; v113 = 807l;
                                                    } else {
                                                        
                                                        
                                                        bool v79;
                                                        v79 = v5 == 233l ;
                                                        
                                                        
                                                        if (v79){
                                                            
                                                            
                                                            v112 = 101l; v113 = 769l;
                                                        } else {
                                                            
                                                            
                                                            bool v80;
                                                            v80 = v5 == 243l ;
                                                            
                                                            
                                                            if (v80){
                                                                
                                                                
                                                                v112 = 111l; v113 = 769l;
                                                            } else {
                                                                
                                                                
                                                                bool v81;
                                                                v81 = v5 == 245l ;
                                                                
                                                                
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
    v114 = v8 == 192l ;
    
    
    int32_t v160; int32_t v161;
    if (v114){
        
        
        v160 = 65l; v161 = 768l;
    } else {
        
        
        bool v115;
        v115 = v8 == 193l ;
        
        
        if (v115){
            
            
            v160 = 65l; v161 = 769l;
        } else {
            
            
            bool v116;
            v116 = v8 == 195l ;
            
            
            if (v116){
                
                
                v160 = 65l; v161 = 771l;
            } else {
                
                
                bool v117;
                v117 = v8 == 196l ;
                
                
                if (v117){
                    
                    
                    v160 = 65l; v161 = 776l;
                } else {
                    
                    
                    bool v118;
                    v118 = v8 == 199l ;
                    
                    
                    if (v118){
                        
                        
                        v160 = 67l; v161 = 807l;
                    } else {
                        
                        
                        bool v119;
                        v119 = v8 == 201l ;
                        
                        
                        if (v119){
                            
                            
                            v160 = 69l; v161 = 769l;
                        } else {
                            
                            
                            bool v120;
                            v120 = v8 == 211l ;
                            
                            
                            if (v120){
                                
                                
                                v160 = 79l; v161 = 769l;
                            } else {
                                
                                
                                bool v121;
                                v121 = v8 == 213l ;
                                
                                
                                if (v121){
                                    
                                    
                                    v160 = 79l; v161 = 771l;
                                } else {
                                    
                                    
                                    bool v122;
                                    v122 = v8 == 224l ;
                                    
                                    
                                    if (v122){
                                        
                                        
                                        v160 = 97l; v161 = 768l;
                                    } else {
                                        
                                        
                                        bool v123;
                                        v123 = v8 == 225l ;
                                        
                                        
                                        if (v123){
                                            
                                            
                                            v160 = 97l; v161 = 769l;
                                        } else {
                                            
                                            
                                            bool v124;
                                            v124 = v8 == 227l ;
                                            
                                            
                                            if (v124){
                                                
                                                
                                                v160 = 97l; v161 = 771l;
                                            } else {
                                                
                                                
                                                bool v125;
                                                v125 = v8 == 228l ;
                                                
                                                
                                                if (v125){
                                                    
                                                    
                                                    v160 = 97l; v161 = 776l;
                                                } else {
                                                    
                                                    
                                                    bool v126;
                                                    v126 = v8 == 231l ;
                                                    
                                                    
                                                    if (v126){
                                                        
                                                        
                                                        v160 = 99l; v161 = 807l;
                                                    } else {
                                                        
                                                        
                                                        bool v127;
                                                        v127 = v8 == 233l ;
                                                        
                                                        
                                                        if (v127){
                                                            
                                                            
                                                            v160 = 101l; v161 = 769l;
                                                        } else {
                                                            
                                                            
                                                            bool v128;
                                                            v128 = v8 == 243l ;
                                                            
                                                            
                                                            if (v128){
                                                                
                                                                
                                                                v160 = 111l; v161 = 769l;
                                                            } else {
                                                                
                                                                
                                                                bool v129;
                                                                v129 = v8 == 245l ;
                                                                
                                                                
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
    v162 = 101l == 65l ;
    
    
    int32_t v209;
    if (v162){
        
        
        bool v163;
        v163 = v11 == 768l ;
        
        
        if (v163){
            
            
            v209 = 192l;
        } else {
            
            
            bool v164;
            v164 = v11 == 769l ;
            
            
            if (v164){
                
                
                v209 = 193l;
            } else {
                
                
                bool v165;
                v165 = v11 == 771l ;
                
                
                if (v165){
                    
                    
                    v209 = 195l;
                } else {
                    
                    
                    bool v166;
                    v166 = v11 == 776l ;
                    
                    
                    if (v166){
                        
                        
                        v209 = 196l;
                    } else {
                        
                        
                        v209 = -1l;
                    }
                }
            }
        }
    } else {
        
        
        bool v171;
        v171 = 101l == 67l ;
        
        
        if (v171){
            
            
            bool v172;
            v172 = v11 == 807l ;
            
            
            if (v172){
                
                
                v209 = 199l;
            } else {
                
                
                v209 = -1l;
            }
        } else {
            
            
            bool v174;
            v174 = 101l == 69l ;
            
            
            if (v174){
                
                
                bool v175;
                v175 = v11 == 769l ;
                
                
                if (v175){
                    
                    
                    v209 = 201l;
                } else {
                    
                    
                    v209 = -1l;
                }
            } else {
                
                
                bool v177;
                v177 = 101l == 79l ;
                
                
                if (v177){
                    
                    
                    bool v178;
                    v178 = v11 == 769l ;
                    
                    
                    if (v178){
                        
                        
                        v209 = 211l;
                    } else {
                        
                        
                        bool v179;
                        v179 = v11 == 771l ;
                        
                        
                        if (v179){
                            
                            
                            v209 = 213l;
                        } else {
                            
                            
                            v209 = -1l;
                        }
                    }
                } else {
                    
                    
                    bool v182;
                    v182 = 101l == 97l ;
                    
                    
                    if (v182){
                        
                        
                        bool v183;
                        v183 = v11 == 768l ;
                        
                        
                        if (v183){
                            
                            
                            v209 = 224l;
                        } else {
                            
                            
                            bool v184;
                            v184 = v11 == 769l ;
                            
                            
                            if (v184){
                                
                                
                                v209 = 225l;
                            } else {
                                
                                
                                bool v185;
                                v185 = v11 == 771l ;
                                
                                
                                if (v185){
                                    
                                    
                                    v209 = 227l;
                                } else {
                                    
                                    
                                    bool v186;
                                    v186 = v11 == 776l ;
                                    
                                    
                                    if (v186){
                                        
                                        
                                        v209 = 228l;
                                    } else {
                                        
                                        
                                        v209 = -1l;
                                    }
                                }
                            }
                        }
                    } else {
                        
                        
                        bool v191;
                        v191 = 101l == 99l ;
                        
                        
                        if (v191){
                            
                            
                            bool v192;
                            v192 = v11 == 807l ;
                            
                            
                            if (v192){
                                
                                
                                v209 = 231l;
                            } else {
                                
                                
                                v209 = -1l;
                            }
                        } else {
                            
                            
                            bool v194;
                            v194 = 101l == 101l ;
                            
                            
                            if (v194){
                                
                                
                                bool v195;
                                v195 = v11 == 769l ;
                                
                                
                                if (v195){
                                    
                                    
                                    v209 = 233l;
                                } else {
                                    
                                    
                                    v209 = -1l;
                                }
                            } else {
                                
                                
                                bool v197;
                                v197 = 101l == 111l ;
                                
                                
                                if (v197){
                                    
                                    
                                    bool v198;
                                    v198 = v11 == 769l ;
                                    
                                    
                                    if (v198){
                                        
                                        
                                        v209 = 243l;
                                    } else {
                                        
                                        
                                        bool v199;
                                        v199 = v11 == 771l ;
                                        
                                        
                                        if (v199){
                                            
                                            
                                            v209 = 245l;
                                        } else {
                                            
                                            
                                            v209 = -1l;
                                        }
                                    }
                                } else {
                                    
                                    
                                    v209 = -1l;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    
    
    bool v210;
    v210 = v209 < 0l;
    
    
    int32_t v211; int32_t v212;
    if (v210){
        
        
        v211 = 101l; v212 = v11;
    } else {
        
        
        v211 = v209; v212 = -1l;
    }
    
    
    bool v213;
    v213 = 111l == 65l ;
    
    
    int32_t v260;
    if (v213){
        
        
        bool v214;
        v214 = v14 == 768l ;
        
        
        if (v214){
            
            
            v260 = 192l;
        } else {
            
            
            bool v215;
            v215 = v14 == 769l ;
            
            
            if (v215){
                
                
                v260 = 193l;
            } else {
                
                
                bool v216;
                v216 = v14 == 771l ;
                
                
                if (v216){
                    
                    
                    v260 = 195l;
                } else {
                    
                    
                    bool v217;
                    v217 = v14 == 776l ;
                    
                    
                    if (v217){
                        
                        
                        v260 = 196l;
                    } else {
                        
                        
                        v260 = -1l;
                    }
                }
            }
        }
    } else {
        
        
        bool v222;
        v222 = 111l == 67l ;
        
        
        if (v222){
            
            
            bool v223;
            v223 = v14 == 807l ;
            
            
            if (v223){
                
                
                v260 = 199l;
            } else {
                
                
                v260 = -1l;
            }
        } else {
            
            
            bool v225;
            v225 = 111l == 69l ;
            
            
            if (v225){
                
                
                bool v226;
                v226 = v14 == 769l ;
                
                
                if (v226){
                    
                    
                    v260 = 201l;
                } else {
                    
                    
                    v260 = -1l;
                }
            } else {
                
                
                bool v228;
                v228 = 111l == 79l ;
                
                
                if (v228){
                    
                    
                    bool v229;
                    v229 = v14 == 769l ;
                    
                    
                    if (v229){
                        
                        
                        v260 = 211l;
                    } else {
                        
                        
                        bool v230;
                        v230 = v14 == 771l ;
                        
                        
                        if (v230){
                            
                            
                            v260 = 213l;
                        } else {
                            
                            
                            v260 = -1l;
                        }
                    }
                } else {
                    
                    
                    bool v233;
                    v233 = 111l == 97l ;
                    
                    
                    if (v233){
                        
                        
                        bool v234;
                        v234 = v14 == 768l ;
                        
                        
                        if (v234){
                            
                            
                            v260 = 224l;
                        } else {
                            
                            
                            bool v235;
                            v235 = v14 == 769l ;
                            
                            
                            if (v235){
                                
                                
                                v260 = 225l;
                            } else {
                                
                                
                                bool v236;
                                v236 = v14 == 771l ;
                                
                                
                                if (v236){
                                    
                                    
                                    v260 = 227l;
                                } else {
                                    
                                    
                                    bool v237;
                                    v237 = v14 == 776l ;
                                    
                                    
                                    if (v237){
                                        
                                        
                                        v260 = 228l;
                                    } else {
                                        
                                        
                                        v260 = -1l;
                                    }
                                }
                            }
                        }
                    } else {
                        
                        
                        bool v242;
                        v242 = 111l == 99l ;
                        
                        
                        if (v242){
                            
                            
                            bool v243;
                            v243 = v14 == 807l ;
                            
                            
                            if (v243){
                                
                                
                                v260 = 231l;
                            } else {
                                
                                
                                v260 = -1l;
                            }
                        } else {
                            
                            
                            bool v245;
                            v245 = 111l == 101l ;
                            
                            
                            if (v245){
                                
                                
                                bool v246;
                                v246 = v14 == 769l ;
                                
                                
                                if (v246){
                                    
                                    
                                    v260 = 233l;
                                } else {
                                    
                                    
                                    v260 = -1l;
                                }
                            } else {
                                
                                
                                bool v248;
                                v248 = 111l == 111l ;
                                
                                
                                if (v248){
                                    
                                    
                                    bool v249;
                                    v249 = v14 == 769l ;
                                    
                                    
                                    if (v249){
                                        
                                        
                                        v260 = 243l;
                                    } else {
                                        
                                        
                                        bool v250;
                                        v250 = v14 == 771l ;
                                        
                                        
                                        if (v250){
                                            
                                            
                                            v260 = 245l;
                                        } else {
                                            
                                            
                                            v260 = -1l;
                                        }
                                    }
                                } else {
                                    
                                    
                                    v260 = -1l;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    
    
    bool v261;
    v261 = v260 < 0l;
    
    
    int32_t v262; int32_t v263;
    if (v261){
        
        
        v262 = 111l; v263 = v14;
    } else {
        
        
        v262 = v260; v263 = -1l;
    }
    
    
    bool v264;
    v264 = 99l == 65l ;
    
    
    int32_t v311;
    if (v264){
        
        
        bool v265;
        v265 = v17 == 768l ;
        
        
        if (v265){
            
            
            v311 = 192l;
        } else {
            
            
            bool v266;
            v266 = v17 == 769l ;
            
            
            if (v266){
                
                
                v311 = 193l;
            } else {
                
                
                bool v267;
                v267 = v17 == 771l ;
                
                
                if (v267){
                    
                    
                    v311 = 195l;
                } else {
                    
                    
                    bool v268;
                    v268 = v17 == 776l ;
                    
                    
                    if (v268){
                        
                        
                        v311 = 196l;
                    } else {
                        
                        
                        v311 = -1l;
                    }
                }
            }
        }
    } else {
        
        
        bool v273;
        v273 = 99l == 67l ;
        
        
        if (v273){
            
            
            bool v274;
            v274 = v17 == 807l ;
            
            
            if (v274){
                
                
                v311 = 199l;
            } else {
                
                
                v311 = -1l;
            }
        } else {
            
            
            bool v276;
            v276 = 99l == 69l ;
            
            
            if (v276){
                
                
                bool v277;
                v277 = v17 == 769l ;
                
                
                if (v277){
                    
                    
                    v311 = 201l;
                } else {
                    
                    
                    v311 = -1l;
                }
            } else {
                
                
                bool v279;
                v279 = 99l == 79l ;
                
                
                if (v279){
                    
                    
                    bool v280;
                    v280 = v17 == 769l ;
                    
                    
                    if (v280){
                        
                        
                        v311 = 211l;
                    } else {
                        
                        
                        bool v281;
                        v281 = v17 == 771l ;
                        
                        
                        if (v281){
                            
                            
                            v311 = 213l;
                        } else {
                            
                            
                            v311 = -1l;
                        }
                    }
                } else {
                    
                    
                    bool v284;
                    v284 = 99l == 97l ;
                    
                    
                    if (v284){
                        
                        
                        bool v285;
                        v285 = v17 == 768l ;
                        
                        
                        if (v285){
                            
                            
                            v311 = 224l;
                        } else {
                            
                            
                            bool v286;
                            v286 = v17 == 769l ;
                            
                            
                            if (v286){
                                
                                
                                v311 = 225l;
                            } else {
                                
                                
                                bool v287;
                                v287 = v17 == 771l ;
                                
                                
                                if (v287){
                                    
                                    
                                    v311 = 227l;
                                } else {
                                    
                                    
                                    bool v288;
                                    v288 = v17 == 776l ;
                                    
                                    
                                    if (v288){
                                        
                                        
                                        v311 = 228l;
                                    } else {
                                        
                                        
                                        v311 = -1l;
                                    }
                                }
                            }
                        }
                    } else {
                        
                        
                        bool v293;
                        v293 = 99l == 99l ;
                        
                        
                        if (v293){
                            
                            
                            bool v294;
                            v294 = v17 == 807l ;
                            
                            
                            if (v294){
                                
                                
                                v311 = 231l;
                            } else {
                                
                                
                                v311 = -1l;
                            }
                        } else {
                            
                            
                            bool v296;
                            v296 = 99l == 101l ;
                            
                            
                            if (v296){
                                
                                
                                bool v297;
                                v297 = v17 == 769l ;
                                
                                
                                if (v297){
                                    
                                    
                                    v311 = 233l;
                                } else {
                                    
                                    
                                    v311 = -1l;
                                }
                            } else {
                                
                                
                                bool v299;
                                v299 = 99l == 111l ;
                                
                                
                                if (v299){
                                    
                                    
                                    bool v300;
                                    v300 = v17 == 769l ;
                                    
                                    
                                    if (v300){
                                        
                                        
                                        v311 = 243l;
                                    } else {
                                        
                                        
                                        bool v301;
                                        v301 = v17 == 771l ;
                                        
                                        
                                        if (v301){
                                            
                                            
                                            v311 = 245l;
                                        } else {
                                            
                                            
                                            v311 = -1l;
                                        }
                                    }
                                } else {
                                    
                                    
                                    v311 = -1l;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    
    
    bool v312;
    v312 = v311 < 0l;
    
    
    int32_t v313; int32_t v314;
    if (v312){
        
        
        v313 = 99l; v314 = v17;
    } else {
        
        
        v313 = v311; v314 = -1l;
    }
    
    
    bool v315;
    v315 = 90l == 192l ;
    
    
    int32_t v361; int32_t v362;
    if (v315){
        
        
        v361 = 65l; v362 = 768l;
    } else {
        
        
        bool v316;
        v316 = 90l == 193l ;
        
        
        if (v316){
            
            
            v361 = 65l; v362 = 769l;
        } else {
            
            
            bool v317;
            v317 = 90l == 195l ;
            
            
            if (v317){
                
                
                v361 = 65l; v362 = 771l;
            } else {
                
                
                bool v318;
                v318 = 90l == 196l ;
                
                
                if (v318){
                    
                    
                    v361 = 65l; v362 = 776l;
                } else {
                    
                    
                    bool v319;
                    v319 = 90l == 199l ;
                    
                    
                    if (v319){
                        
                        
                        v361 = 67l; v362 = 807l;
                    } else {
                        
                        
                        bool v320;
                        v320 = 90l == 201l ;
                        
                        
                        if (v320){
                            
                            
                            v361 = 69l; v362 = 769l;
                        } else {
                            
                            
                            bool v321;
                            v321 = 90l == 211l ;
                            
                            
                            if (v321){
                                
                                
                                v361 = 79l; v362 = 769l;
                            } else {
                                
                                
                                bool v322;
                                v322 = 90l == 213l ;
                                
                                
                                if (v322){
                                    
                                    
                                    v361 = 79l; v362 = 771l;
                                } else {
                                    
                                    
                                    bool v323;
                                    v323 = 90l == 224l ;
                                    
                                    
                                    if (v323){
                                        
                                        
                                        v361 = 97l; v362 = 768l;
                                    } else {
                                        
                                        
                                        bool v324;
                                        v324 = 90l == 225l ;
                                        
                                        
                                        if (v324){
                                            
                                            
                                            v361 = 97l; v362 = 769l;
                                        } else {
                                            
                                            
                                            bool v325;
                                            v325 = 90l == 227l ;
                                            
                                            
                                            if (v325){
                                                
                                                
                                                v361 = 97l; v362 = 771l;
                                            } else {
                                                
                                                
                                                bool v326;
                                                v326 = 90l == 228l ;
                                                
                                                
                                                if (v326){
                                                    
                                                    
                                                    v361 = 97l; v362 = 776l;
                                                } else {
                                                    
                                                    
                                                    bool v327;
                                                    v327 = 90l == 231l ;
                                                    
                                                    
                                                    if (v327){
                                                        
                                                        
                                                        v361 = 99l; v362 = 807l;
                                                    } else {
                                                        
                                                        
                                                        bool v328;
                                                        v328 = 90l == 233l ;
                                                        
                                                        
                                                        if (v328){
                                                            
                                                            
                                                            v361 = 101l; v362 = 769l;
                                                        } else {
                                                            
                                                            
                                                            bool v329;
                                                            v329 = 90l == 243l ;
                                                            
                                                            
                                                            if (v329){
                                                                
                                                                
                                                                v361 = 111l; v362 = 769l;
                                                            } else {
                                                                
                                                                
                                                                bool v330;
                                                                v330 = 90l == 245l ;
                                                                
                                                                
                                                                if (v330){
                                                                    
                                                                    
                                                                    v361 = 111l; v362 = 771l;
                                                                } else {
                                                                    
                                                                    
                                                                    v361 = 90l; v362 = -1l;
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
    
    
    bool v363;
    v363 = 90l == 65l ;
    
    
    int32_t v410;
    if (v363){
        
        
        bool v364;
        v364 = v11 == 768l ;
        
        
        if (v364){
            
            
            v410 = 192l;
        } else {
            
            
            bool v365;
            v365 = v11 == 769l ;
            
            
            if (v365){
                
                
                v410 = 193l;
            } else {
                
                
                bool v366;
                v366 = v11 == 771l ;
                
                
                if (v366){
                    
                    
                    v410 = 195l;
                } else {
                    
                    
                    bool v367;
                    v367 = v11 == 776l ;
                    
                    
                    if (v367){
                        
                        
                        v410 = 196l;
                    } else {
                        
                        
                        v410 = -1l;
                    }
                }
            }
        }
    } else {
        
        
        bool v372;
        v372 = 90l == 67l ;
        
        
        if (v372){
            
            
            bool v373;
            v373 = v11 == 807l ;
            
            
            if (v373){
                
                
                v410 = 199l;
            } else {
                
                
                v410 = -1l;
            }
        } else {
            
            
            bool v375;
            v375 = 90l == 69l ;
            
            
            if (v375){
                
                
                bool v376;
                v376 = v11 == 769l ;
                
                
                if (v376){
                    
                    
                    v410 = 201l;
                } else {
                    
                    
                    v410 = -1l;
                }
            } else {
                
                
                bool v378;
                v378 = 90l == 79l ;
                
                
                if (v378){
                    
                    
                    bool v379;
                    v379 = v11 == 769l ;
                    
                    
                    if (v379){
                        
                        
                        v410 = 211l;
                    } else {
                        
                        
                        bool v380;
                        v380 = v11 == 771l ;
                        
                        
                        if (v380){
                            
                            
                            v410 = 213l;
                        } else {
                            
                            
                            v410 = -1l;
                        }
                    }
                } else {
                    
                    
                    bool v383;
                    v383 = 90l == 97l ;
                    
                    
                    if (v383){
                        
                        
                        bool v384;
                        v384 = v11 == 768l ;
                        
                        
                        if (v384){
                            
                            
                            v410 = 224l;
                        } else {
                            
                            
                            bool v385;
                            v385 = v11 == 769l ;
                            
                            
                            if (v385){
                                
                                
                                v410 = 225l;
                            } else {
                                
                                
                                bool v386;
                                v386 = v11 == 771l ;
                                
                                
                                if (v386){
                                    
                                    
                                    v410 = 227l;
                                } else {
                                    
                                    
                                    bool v387;
                                    v387 = v11 == 776l ;
                                    
                                    
                                    if (v387){
                                        
                                        
                                        v410 = 228l;
                                    } else {
                                        
                                        
                                        v410 = -1l;
                                    }
                                }
                            }
                        }
                    } else {
                        
                        
                        bool v392;
                        v392 = 90l == 99l ;
                        
                        
                        if (v392){
                            
                            
                            bool v393;
                            v393 = v11 == 807l ;
                            
                            
                            if (v393){
                                
                                
                                v410 = 231l;
                            } else {
                                
                                
                                v410 = -1l;
                            }
                        } else {
                            
                            
                            bool v395;
                            v395 = 90l == 101l ;
                            
                            
                            if (v395){
                                
                                
                                bool v396;
                                v396 = v11 == 769l ;
                                
                                
                                if (v396){
                                    
                                    
                                    v410 = 233l;
                                } else {
                                    
                                    
                                    v410 = -1l;
                                }
                            } else {
                                
                                
                                bool v398;
                                v398 = 90l == 111l ;
                                
                                
                                if (v398){
                                    
                                    
                                    bool v399;
                                    v399 = v11 == 769l ;
                                    
                                    
                                    if (v399){
                                        
                                        
                                        v410 = 243l;
                                    } else {
                                        
                                        
                                        bool v400;
                                        v400 = v11 == 771l ;
                                        
                                        
                                        if (v400){
                                            
                                            
                                            v410 = 245l;
                                        } else {
                                            
                                            
                                            v410 = -1l;
                                        }
                                    }
                                } else {
                                    
                                    
                                    v410 = -1l;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    
    
    bool v411;
    v411 = v410 < 0l;
    
    
    int32_t v412; int32_t v413;
    if (v411){
        
        
        v412 = 90l; v413 = v11;
    } else {
        
        
        v412 = v410; v413 = -1l;
    }
    
    
    bool v414;
    v414 = v64 == 101l ;
    
    
    bool v416;
    if (v414){
        
        
        bool v415;
        v415 = v65 == v11 ;
        
        
        v416 = v415;
    } else {
        
        
        v416 = false;
    }
    
    
    if (v416){
        
        
        bool v417;
        v417 = v112 == 111l ;
        
        
        bool v419;
        if (v417){
            
            
            bool v418;
            v418 = v113 == v14 ;
            
            
            v419 = v418;
        } else {
            
            
            v419 = false;
        }
        
        
        if (v419){
            
            
            bool v420;
            v420 = v160 == 99l ;
            
            
            bool v422;
            if (v420){
                
                
                bool v421;
                v421 = v161 == v17 ;
                
                
                v422 = v421;
            } else {
                
                
                v422 = false;
            }
            
            
            if (v422){
                
                
                bool v423;
                v423 = v211 == v2 ;
                
                
                bool v425;
                if (v423){
                    
                    
                    bool v424;
                    v424 = v212 == -1l ;
                    
                    
                    v425 = v424;
                } else {
                    
                    
                    v425 = false;
                }
                
                
                if (v425){
                    
                    
                    bool v426;
                    v426 = v262 == v5 ;
                    
                    
                    bool v428;
                    if (v426){
                        
                        
                        bool v427;
                        v427 = v263 == -1l ;
                        
                        
                        v428 = v427;
                    } else {
                        
                        
                        v428 = false;
                    }
                    
                    
                    if (v428){
                        
                        
                        bool v429;
                        v429 = v313 == v8 ;
                        
                        
                        bool v431;
                        if (v429){
                            
                            
                            bool v430;
                            v430 = v314 == -1l ;
                            
                            
                            v431 = v430;
                        } else {
                            
                            
                            v431 = false;
                        }
                        
                        
                        if (v431){
                            
                            
                            bool v432;
                            v432 = v361 == 90l ;
                            
                            
                            bool v434;
                            if (v432){
                                
                                
                                bool v433;
                                v433 = v362 == -1l ;
                                
                                
                                v434 = v433;
                            } else {
                                
                                
                                v434 = false;
                            }
                            
                            
                            if (v434){
                                
                                
                                bool v435;
                                v435 = v412 == 90l ;
                                
                                
                                bool v437;
                                if (v435){
                                    
                                    
                                    bool v436;
                                    v436 = v413 == v11 ;
                                    
                                    
                                    v437 = v436;
                                } else {
                                    
                                    
                                    v437 = false;
                                }
                                
                                
                                if (v437){
                                    
                                    
                                    return 0l;
                                } else {
                                    
                                    
                                    return 8l;
                                }
                            } else {
                                
                                
                                return 7l;
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
