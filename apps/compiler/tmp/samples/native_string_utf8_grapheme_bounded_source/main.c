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
int32_t utf8_grapheme_count_bounded_loop0(String * v0, int32_t v1, int32_t v2, int32_t v3){
    
    
    bool v4;
    v4 = v1 == v3 ;
    
    
    if (v4){
        
        StringDecref(v0);
        return v2;
    } else {
        
        
        bool v5;
        v5 = v1 > v3;
        
        
        if (v5){
            
            StringDecref(v0);
            fprintf(stderr, "%s\n", "UTF-8 scalar width exceeds the string.");
            exit(EXIT_FAILURE);
        } else {
            v0->refc++;
            
            int32_t v7;
            v7 = utf8_scalar_at_byte_offset1(v0, v1);
            
            
            bool v8;
            v8 = v7 < 128l;
            
            
            int32_t v13;
            if (v8){
                
                
                v13 = 1l;
            } else {
                
                
                bool v9;
                v9 = v7 < 2048l;
                
                
                if (v9){
                    
                    
                    v13 = 2l;
                } else {
                    
                    
                    bool v10;
                    v10 = v7 < 65536l;
                    
                    
                    if (v10){
                        
                        
                        v13 = 3l;
                    } else {
                        
                        
                        v13 = 4l;
                    }
                }
            }
            
            
            bool v14;
            v14 = v7 >= 768l;
            
            
            bool v44;
            if (v14){
                
                
                bool v15;
                v15 = v7 <= 879l;
                
                
                if (v15){
                    
                    
                    v44 = true;
                } else {
                    
                    
                    bool v16;
                    v16 = v7 >= 6832l;
                    
                    
                    if (v16){
                        
                        
                        bool v17;
                        v17 = v7 <= 6911l;
                        
                        
                        if (v17){
                            
                            
                            v44 = true;
                        } else {
                            
                            
                            bool v18;
                            v18 = v7 >= 7616l;
                            
                            
                            if (v18){
                                
                                
                                bool v19;
                                v19 = v7 <= 7679l;
                                
                                
                                if (v19){
                                    
                                    
                                    v44 = true;
                                } else {
                                    
                                    
                                    bool v20;
                                    v20 = v7 >= 8400l;
                                    
                                    
                                    if (v20){
                                        
                                        
                                        bool v21;
                                        v21 = v7 <= 8447l;
                                        
                                        
                                        if (v21){
                                            
                                            
                                            v44 = true;
                                        } else {
                                            
                                            
                                            bool v22;
                                            v22 = v7 >= 65024l;
                                            
                                            
                                            if (v22){
                                                
                                                
                                                bool v23;
                                                v23 = v7 <= 65039l;
                                                
                                                
                                                if (v23){
                                                    
                                                    
                                                    v44 = true;
                                                } else {
                                                    
                                                    
                                                    bool v24;
                                                    v24 = v7 >= 65056l;
                                                    
                                                    
                                                    if (v24){
                                                        
                                                        
                                                        bool v25;
                                                        v25 = v7 <= 65071l;
                                                        
                                                        
                                                        if (v25){
                                                            
                                                            
                                                            v44 = true;
                                                        } else {
                                                            
                                                            
                                                            bool v26;
                                                            v26 = v7 >= 127995l;
                                                            
                                                            
                                                            if (v26){
                                                                
                                                                
                                                                bool v27;
                                                                v27 = v7 <= 127999l;
                                                                
                                                                
                                                                if (v27){
                                                                    
                                                                    
                                                                    v44 = true;
                                                                } else {
                                                                    
                                                                    
                                                                    bool v28;
                                                                    v28 = v7 >= 917760l;
                                                                    
                                                                    
                                                                    if (v28){
                                                                        
                                                                        
                                                                        bool v29;
                                                                        v29 = v7 <= 917999l;
                                                                        
                                                                        
                                                                        v44 = v29;
                                                                    } else {
                                                                        
                                                                        
                                                                        v44 = false;
                                                                    }
                                                                }
                                                            } else {
                                                                
                                                                
                                                                v44 = false;
                                                            }
                                                        }
                                                    } else {
                                                        
                                                        
                                                        v44 = false;
                                                    }
                                                }
                                            } else {
                                                
                                                
                                                v44 = false;
                                            }
                                        }
                                    } else {
                                        
                                        
                                        v44 = false;
                                    }
                                }
                            } else {
                                
                                
                                v44 = false;
                            }
                        }
                    } else {
                        
                        
                        v44 = false;
                    }
                }
            } else {
                
                
                v44 = false;
            }
            
            
            int32_t v48;
            if (v44){
                
                
                bool v45;
                v45 = v2 == 0l ;
                
                
                if (v45){
                    
                    
                    v48 = 1l;
                } else {
                    
                    
                    v48 = v2;
                }
            } else {
                
                
                int32_t v47;
                v47 = v2 + 1l ;
                
                
                v48 = v47;
            }
            
            
            int32_t v49;
            v49 = v1 + v13 ;
            
            
            return utf8_grapheme_count_bounded_loop0(v0, v49, v48, v3);
        }
    }
}
int32_t main(){
    
    
    bool v0;
    v0 = 0l == 21l ;
    
    
    int32_t v6;
    if (v0){
        
        
        v6 = 0l;
    } else {
        
        
        String * v1;
        v1 = StringLit(22, "Aéé☕️👍🏽Z");
        
        
        int32_t v2;
        v2 = 0l;
        
        
        int32_t v3;
        v3 = 0l;
        
        
        int32_t v4;
        v4 = 21l;
        
        
        v6 = utf8_grapheme_count_bounded_loop0(v1, v2, v3, v4);
    }
    
    
    bool v7;
    v7 = 0l == 5l ;
    
    
    int32_t v13;
    if (v7){
        
        
        v13 = 0l;
    } else {
        
        
        String * v8;
        v8 = StringLit(6, "́̈A");
        
        
        int32_t v9;
        v9 = 0l;
        
        
        int32_t v10;
        v10 = 0l;
        
        
        int32_t v11;
        v11 = 5l;
        
        
        v13 = utf8_grapheme_count_bounded_loop0(v8, v9, v10, v11);
    }
    
    
    bool v14;
    v14 = 0l == 0l ;
    
    
    int32_t v20;
    if (v14){
        
        
        v20 = 0l;
    } else {
        
        
        String * v15;
        v15 = StringLit(1, "");
        
        
        int32_t v16;
        v16 = 0l;
        
        
        int32_t v17;
        v17 = 0l;
        
        
        int32_t v18;
        v18 = 0l;
        
        
        v20 = utf8_grapheme_count_bounded_loop0(v15, v16, v17, v18);
    }
    
    
    bool v21;
    v21 = 4l == 9l ;
    
    
    int32_t v62;
    if (v21){
        
        
        v62 = 0l;
    } else {
        
        
        String * v22;
        v22 = StringLit(10, "Aé🙂Z");
        
        
        int32_t v23;
        v23 = 4l;
        v22->refc++;
        
        int32_t v24;
        v24 = utf8_scalar_at_byte_offset1(v22, v23);
        
        
        bool v25;
        v25 = v24 >= 768l;
        
        
        bool v55;
        if (v25){
            
            
            bool v26;
            v26 = v24 <= 879l;
            
            
            if (v26){
                
                
                v55 = true;
            } else {
                
                
                bool v27;
                v27 = v24 >= 6832l;
                
                
                if (v27){
                    
                    
                    bool v28;
                    v28 = v24 <= 6911l;
                    
                    
                    if (v28){
                        
                        
                        v55 = true;
                    } else {
                        
                        
                        bool v29;
                        v29 = v24 >= 7616l;
                        
                        
                        if (v29){
                            
                            
                            bool v30;
                            v30 = v24 <= 7679l;
                            
                            
                            if (v30){
                                
                                
                                v55 = true;
                            } else {
                                
                                
                                bool v31;
                                v31 = v24 >= 8400l;
                                
                                
                                if (v31){
                                    
                                    
                                    bool v32;
                                    v32 = v24 <= 8447l;
                                    
                                    
                                    if (v32){
                                        
                                        
                                        v55 = true;
                                    } else {
                                        
                                        
                                        bool v33;
                                        v33 = v24 >= 65024l;
                                        
                                        
                                        if (v33){
                                            
                                            
                                            bool v34;
                                            v34 = v24 <= 65039l;
                                            
                                            
                                            if (v34){
                                                
                                                
                                                v55 = true;
                                            } else {
                                                
                                                
                                                bool v35;
                                                v35 = v24 >= 65056l;
                                                
                                                
                                                if (v35){
                                                    
                                                    
                                                    bool v36;
                                                    v36 = v24 <= 65071l;
                                                    
                                                    
                                                    if (v36){
                                                        
                                                        
                                                        v55 = true;
                                                    } else {
                                                        
                                                        
                                                        bool v37;
                                                        v37 = v24 >= 127995l;
                                                        
                                                        
                                                        if (v37){
                                                            
                                                            
                                                            bool v38;
                                                            v38 = v24 <= 127999l;
                                                            
                                                            
                                                            if (v38){
                                                                
                                                                
                                                                v55 = true;
                                                            } else {
                                                                
                                                                
                                                                bool v39;
                                                                v39 = v24 >= 917760l;
                                                                
                                                                
                                                                if (v39){
                                                                    
                                                                    
                                                                    bool v40;
                                                                    v40 = v24 <= 917999l;
                                                                    
                                                                    
                                                                    v55 = v40;
                                                                } else {
                                                                    
                                                                    
                                                                    v55 = false;
                                                                }
                                                            }
                                                        } else {
                                                            
                                                            
                                                            v55 = false;
                                                        }
                                                    }
                                                } else {
                                                    
                                                    
                                                    v55 = false;
                                                }
                                            }
                                        } else {
                                            
                                            
                                            v55 = false;
                                        }
                                    }
                                } else {
                                    
                                    
                                    v55 = false;
                                }
                            }
                        } else {
                            
                            
                            v55 = false;
                        }
                    }
                } else {
                    
                    
                    v55 = false;
                }
            }
        } else {
            
            
            v55 = false;
        }
        
        
        if (v55){
            
            StringDecref(v22);
            fprintf(stderr, "%s\n", "UTF-8 grapheme byte offset is inside a bounded grapheme cluster.");
            exit(EXIT_FAILURE);
        } else {
            
            
            int32_t v57;
            v57 = 4l;
            
            
            int32_t v58;
            v58 = 0l;
            
            
            int32_t v59;
            v59 = 9l;
            
            
            v62 = utf8_grapheme_count_bounded_loop0(v22, v57, v58, v59);
        }
    }
    
    
    bool v63;
    v63 = v6 == 6l ;
    
    
    if (v63){
        
        
        bool v64;
        v64 = v13 == 2l ;
        
        
        if (v64){
            
            
            bool v65;
            v65 = v20 == 0l ;
            
            
            if (v65){
                
                
                bool v66;
                v66 = v62 == 2l ;
                
                
                if (v66){
                    
                    
                    return 0l;
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
