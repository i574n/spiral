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
int32_t utf8_grapheme_count_bounded_loop2(String * v0, int32_t v1, int32_t v2, int32_t v3){
    
    
    bool v4;
    v4 = v1 == v3;
    
    
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
            v7 = utf8_scalar_at_byte_offset0(v0, v1);
            
            
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
                v45 = v2 == 0l;
                
                
                if (v45){
                    
                    
                    v48 = 1l;
                } else {
                    
                    
                    v48 = v2;
                }
            } else {
                
                
                int32_t v47;
                v47 = v2 + 1l;
                
                
                v48 = v47;
            }
            
            
            int32_t v49;
            v49 = v1 + v13;
            
            
            return utf8_grapheme_count_bounded_loop2(v0, v49, v48, v3);
        }
    }
}
int32_t main(){
    
    
    String * v0;
    v0 = StringLit(5, "éZ");
    
    
    int32_t v1;
    v1 = 1l;
    v0->refc++;
    
    int32_t v2;
    v2 = utf8_scalar_at_byte_offset0(v0, v1);
    
    
    bool v3;
    v3 = v2 >= 768l;
    
    
    bool v33;
    if (v3){
        
        
        bool v4;
        v4 = v2 <= 879l;
        
        
        if (v4){
            
            
            v33 = true;
        } else {
            
            
            bool v5;
            v5 = v2 >= 6832l;
            
            
            if (v5){
                
                
                bool v6;
                v6 = v2 <= 6911l;
                
                
                if (v6){
                    
                    
                    v33 = true;
                } else {
                    
                    
                    bool v7;
                    v7 = v2 >= 7616l;
                    
                    
                    if (v7){
                        
                        
                        bool v8;
                        v8 = v2 <= 7679l;
                        
                        
                        if (v8){
                            
                            
                            v33 = true;
                        } else {
                            
                            
                            bool v9;
                            v9 = v2 >= 8400l;
                            
                            
                            if (v9){
                                
                                
                                bool v10;
                                v10 = v2 <= 8447l;
                                
                                
                                if (v10){
                                    
                                    
                                    v33 = true;
                                } else {
                                    
                                    
                                    bool v11;
                                    v11 = v2 >= 65024l;
                                    
                                    
                                    if (v11){
                                        
                                        
                                        bool v12;
                                        v12 = v2 <= 65039l;
                                        
                                        
                                        if (v12){
                                            
                                            
                                            v33 = true;
                                        } else {
                                            
                                            
                                            bool v13;
                                            v13 = v2 >= 65056l;
                                            
                                            
                                            if (v13){
                                                
                                                
                                                bool v14;
                                                v14 = v2 <= 65071l;
                                                
                                                
                                                if (v14){
                                                    
                                                    
                                                    v33 = true;
                                                } else {
                                                    
                                                    
                                                    bool v15;
                                                    v15 = v2 >= 127995l;
                                                    
                                                    
                                                    if (v15){
                                                        
                                                        
                                                        bool v16;
                                                        v16 = v2 <= 127999l;
                                                        
                                                        
                                                        if (v16){
                                                            
                                                            
                                                            v33 = true;
                                                        } else {
                                                            
                                                            
                                                            bool v17;
                                                            v17 = v2 >= 917760l;
                                                            
                                                            
                                                            if (v17){
                                                                
                                                                
                                                                bool v18;
                                                                v18 = v2 <= 917999l;
                                                                
                                                                
                                                                v33 = v18;
                                                            } else {
                                                                
                                                                
                                                                v33 = false;
                                                            }
                                                        }
                                                    } else {
                                                        
                                                        
                                                        v33 = false;
                                                    }
                                                }
                                            } else {
                                                
                                                
                                                v33 = false;
                                            }
                                        }
                                    } else {
                                        
                                        
                                        v33 = false;
                                    }
                                }
                            } else {
                                
                                
                                v33 = false;
                            }
                        }
                    } else {
                        
                        
                        v33 = false;
                    }
                }
            } else {
                
                
                v33 = false;
            }
        }
    } else {
        
        
        v33 = false;
    }
    
    
    if (v33){
        
        StringDecref(v0);
        fprintf(stderr, "%s\n", "UTF-8 grapheme byte offset is inside a bounded grapheme cluster.");
        exit(EXIT_FAILURE);
    } else {
        
        
        int32_t v35;
        v35 = 1l;
        
        
        int32_t v36;
        v36 = 0l;
        
        
        int32_t v37;
        v37 = 4l;
        
        
        return utf8_grapheme_count_bounded_loop2(v0, v35, v36, v37);
    }
}
