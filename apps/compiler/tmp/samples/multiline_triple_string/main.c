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
int32_t main(){
    
    
    int32_t v0;
    v0 = 16l;
    
    
    String * v1;
    v1 = StringLit(4, "x\ny");
    
    
    String * v2;
    v2 = StringLit(9, "say \"hi\"");
    
    
    String * v3;
    v3 = StringLit(8, "a \"\"\" b");
    
    
    String * v4;
    v4 = StringLit(24, "first\n    second\n\nthird");
    
    
    String * v5;
    v5 = StringLit(6, "ab\ncd");
    
    
    String * v6;
    v6 = StringLit(8, "a \"b\" c");
    
    
    String * v7;
    v7 = StringLit(1, "");
    
    
    String * v8;
    v8 = StringLit(5, "a\\nb");
    
    
    String * v9;
    v9 = StringLit(84, "first\n(* not a comment *)\n// nor this\n\n$\"not a macro\" !x\ninl fake () = 1\n  indented");
    
    
    String * v10;
    v10 = StringLit(12, "\ntop\n\nlevel");
    
    
    int32_t v11;
    v11 = v6->len-1;
    
    
    bool v12;
    v12 = v11 == 7l;
    
    
    bool v13;
    v13 = v12 != true;
    
    
    if (v13){
        
        StringDecref(v1); StringDecref(v2); StringDecref(v3); StringDecref(v4); StringDecref(v5); StringDecref(v6); StringDecref(v7); StringDecref(v8); StringDecref(v9); StringDecref(v10);
        return 1l;
    } else {
        
        
        char v14;
        v14 = v6->ptr[2l];
        
        StringDecref(v6);
        bool v15;
        v15 = v14 == '"';
        
        
        bool v16;
        v16 = v15 != true;
        
        
        if (v16){
            
            StringDecref(v1); StringDecref(v2); StringDecref(v3); StringDecref(v4); StringDecref(v5); StringDecref(v7); StringDecref(v8); StringDecref(v9); StringDecref(v10);
            return 2l;
        } else {
            
            
            int32_t v17;
            v17 = v7->len-1;
            
            StringDecref(v7);
            bool v18;
            v18 = v17 == 0l;
            
            
            bool v19;
            v19 = v18 != true;
            
            
            if (v19){
                
                StringDecref(v1); StringDecref(v2); StringDecref(v3); StringDecref(v4); StringDecref(v5); StringDecref(v8); StringDecref(v9); StringDecref(v10);
                return 3l;
            } else {
                
                
                int32_t v20;
                v20 = v8->len-1;
                
                
                bool v21;
                v21 = v20 == 4l;
                
                
                bool v22;
                v22 = v21 != true;
                
                
                if (v22){
                    
                    StringDecref(v1); StringDecref(v2); StringDecref(v3); StringDecref(v4); StringDecref(v5); StringDecref(v8); StringDecref(v9); StringDecref(v10);
                    return 4l;
                } else {
                    
                    
                    char v23;
                    v23 = v8->ptr[1l];
                    
                    StringDecref(v8);
                    bool v24;
                    v24 = v23 == '\\';
                    
                    
                    bool v25;
                    v25 = v24 != true;
                    
                    
                    if (v25){
                        
                        StringDecref(v1); StringDecref(v2); StringDecref(v3); StringDecref(v4); StringDecref(v5); StringDecref(v9); StringDecref(v10);
                        return 5l;
                    } else {
                        
                        
                        int32_t v26;
                        v26 = v9->len-1;
                        
                        
                        bool v27;
                        v27 = v26 == 83l;
                        
                        
                        bool v28;
                        v28 = v27 != true;
                        
                        
                        if (v28){
                            
                            StringDecref(v1); StringDecref(v2); StringDecref(v3); StringDecref(v4); StringDecref(v5); StringDecref(v9); StringDecref(v10);
                            return 6l;
                        } else {
                            
                            
                            char v29;
                            v29 = v9->ptr[5l];
                            
                            
                            bool v30;
                            v30 = v29 == '\n';
                            
                            
                            bool v31;
                            v31 = v30 != true;
                            
                            
                            if (v31){
                                
                                StringDecref(v1); StringDecref(v2); StringDecref(v3); StringDecref(v4); StringDecref(v5); StringDecref(v9); StringDecref(v10);
                                return 7l;
                            } else {
                                
                                
                                char v32;
                                v32 = v9->ptr[37l];
                                
                                
                                bool v33;
                                v33 = v32 == '\n';
                                
                                
                                bool v34;
                                v34 = v33 != true;
                                
                                
                                if (v34){
                                    
                                    StringDecref(v1); StringDecref(v2); StringDecref(v3); StringDecref(v4); StringDecref(v5); StringDecref(v9); StringDecref(v10);
                                    return 8l;
                                } else {
                                    
                                    
                                    char v35;
                                    v35 = v9->ptr[38l];
                                    
                                    
                                    bool v36;
                                    v36 = v35 == '\n';
                                    
                                    
                                    bool v37;
                                    v37 = v36 != true;
                                    
                                    
                                    if (v37){
                                        
                                        StringDecref(v1); StringDecref(v2); StringDecref(v3); StringDecref(v4); StringDecref(v5); StringDecref(v9); StringDecref(v10);
                                        return 9l;
                                    } else {
                                        
                                        
                                        char v38;
                                        v38 = v9->ptr[39l];
                                        
                                        
                                        bool v39;
                                        v39 = v38 == '$';
                                        
                                        
                                        bool v40;
                                        v40 = v39 != true;
                                        
                                        
                                        if (v40){
                                            
                                            StringDecref(v1); StringDecref(v2); StringDecref(v3); StringDecref(v4); StringDecref(v5); StringDecref(v9); StringDecref(v10);
                                            return 10l;
                                        } else {
                                            
                                            
                                            char v41;
                                            v41 = v9->ptr[57l];
                                            
                                            
                                            bool v42;
                                            v42 = v41 == 'i';
                                            
                                            
                                            bool v43;
                                            v43 = v42 != true;
                                            
                                            
                                            if (v43){
                                                
                                                StringDecref(v1); StringDecref(v2); StringDecref(v3); StringDecref(v4); StringDecref(v5); StringDecref(v9); StringDecref(v10);
                                                return 11l;
                                            } else {
                                                
                                                
                                                char v44;
                                                v44 = v9->ptr[82l];
                                                
                                                StringDecref(v9);
                                                bool v45;
                                                v45 = v44 == 'd';
                                                
                                                
                                                bool v46;
                                                v46 = v45 != true;
                                                
                                                
                                                if (v46){
                                                    
                                                    StringDecref(v1); StringDecref(v2); StringDecref(v3); StringDecref(v4); StringDecref(v5); StringDecref(v10);
                                                    return 12l;
                                                } else {
                                                    
                                                    
                                                    int32_t v47;
                                                    v47 = v10->len-1;
                                                    
                                                    
                                                    bool v48;
                                                    v48 = v47 == 11l;
                                                    
                                                    
                                                    bool v49;
                                                    v49 = v48 != true;
                                                    
                                                    
                                                    if (v49){
                                                        
                                                        StringDecref(v1); StringDecref(v2); StringDecref(v3); StringDecref(v4); StringDecref(v5); StringDecref(v10);
                                                        return 13l;
                                                    } else {
                                                        
                                                        
                                                        char v50;
                                                        v50 = v10->ptr[0l];
                                                        
                                                        
                                                        bool v51;
                                                        v51 = v50 == '\n';
                                                        
                                                        
                                                        bool v52;
                                                        v52 = v51 != true;
                                                        
                                                        
                                                        if (v52){
                                                            
                                                            StringDecref(v1); StringDecref(v2); StringDecref(v3); StringDecref(v4); StringDecref(v5); StringDecref(v10);
                                                            return 14l;
                                                        } else {
                                                            
                                                            
                                                            char v53;
                                                            v53 = v10->ptr[5l];
                                                            
                                                            StringDecref(v10);
                                                            bool v54;
                                                            v54 = v53 == '\n';
                                                            
                                                            
                                                            bool v55;
                                                            v55 = v54 != true;
                                                            
                                                            
                                                            if (v55){
                                                                
                                                                StringDecref(v1); StringDecref(v2); StringDecref(v3); StringDecref(v4); StringDecref(v5);
                                                                return 15l;
                                                            } else {
                                                                
                                                                
                                                                bool v56;
                                                                v56 = v0 == 16l;
                                                                
                                                                
                                                                bool v57;
                                                                v57 = v56 != true;
                                                                
                                                                
                                                                if (v57){
                                                                    
                                                                    StringDecref(v1); StringDecref(v2); StringDecref(v3); StringDecref(v4); StringDecref(v5);
                                                                    return 16l;
                                                                } else {
                                                                    
                                                                    
                                                                    int32_t v58;
                                                                    v58 = v1->len-1;
                                                                    
                                                                    StringDecref(v1);
                                                                    bool v59;
                                                                    v59 = v58 == 3l;
                                                                    
                                                                    
                                                                    bool v60;
                                                                    v60 = v59 != true;
                                                                    
                                                                    
                                                                    if (v60){
                                                                        
                                                                        StringDecref(v2); StringDecref(v3); StringDecref(v4); StringDecref(v5);
                                                                        return 17l;
                                                                    } else {
                                                                        
                                                                        
                                                                        int32_t v61;
                                                                        v61 = v2->len-1;
                                                                        
                                                                        
                                                                        bool v62;
                                                                        v62 = v61 == 8l;
                                                                        
                                                                        
                                                                        bool v63;
                                                                        v63 = v62 != true;
                                                                        
                                                                        
                                                                        if (v63){
                                                                            
                                                                            StringDecref(v2); StringDecref(v3); StringDecref(v4); StringDecref(v5);
                                                                            return 18l;
                                                                        } else {
                                                                            
                                                                            
                                                                            char v64;
                                                                            v64 = v2->ptr[7l];
                                                                            
                                                                            StringDecref(v2);
                                                                            bool v65;
                                                                            v65 = v64 == '"';
                                                                            
                                                                            
                                                                            bool v66;
                                                                            v66 = v65 != true;
                                                                            
                                                                            
                                                                            if (v66){
                                                                                
                                                                                StringDecref(v3); StringDecref(v4); StringDecref(v5);
                                                                                return 19l;
                                                                            } else {
                                                                                
                                                                                
                                                                                int32_t v67;
                                                                                v67 = v3->len-1;
                                                                                
                                                                                
                                                                                bool v68;
                                                                                v68 = v67 == 7l;
                                                                                
                                                                                
                                                                                bool v69;
                                                                                v69 = v68 != true;
                                                                                
                                                                                
                                                                                if (v69){
                                                                                    
                                                                                    StringDecref(v3); StringDecref(v4); StringDecref(v5);
                                                                                    return 20l;
                                                                                } else {
                                                                                    
                                                                                    
                                                                                    char v70;
                                                                                    v70 = v3->ptr[4l];
                                                                                    
                                                                                    StringDecref(v3);
                                                                                    bool v71;
                                                                                    v71 = v70 == '"';
                                                                                    
                                                                                    
                                                                                    bool v72;
                                                                                    v72 = v71 != true;
                                                                                    
                                                                                    
                                                                                    if (v72){
                                                                                        
                                                                                        StringDecref(v4); StringDecref(v5);
                                                                                        return 21l;
                                                                                    } else {
                                                                                        
                                                                                        
                                                                                        int32_t v73;
                                                                                        v73 = v4->len-1;
                                                                                        
                                                                                        
                                                                                        bool v74;
                                                                                        v74 = v73 == 23l;
                                                                                        
                                                                                        
                                                                                        bool v75;
                                                                                        v75 = v74 != true;
                                                                                        
                                                                                        
                                                                                        if (v75){
                                                                                            
                                                                                            StringDecref(v4); StringDecref(v5);
                                                                                            return 22l;
                                                                                        } else {
                                                                                            
                                                                                            
                                                                                            char v76;
                                                                                            v76 = v4->ptr[6l];
                                                                                            
                                                                                            
                                                                                            bool v77;
                                                                                            v77 = v76 == ' ';
                                                                                            
                                                                                            
                                                                                            bool v78;
                                                                                            v78 = v77 != true;
                                                                                            
                                                                                            
                                                                                            if (v78){
                                                                                                
                                                                                                StringDecref(v4); StringDecref(v5);
                                                                                                return 23l;
                                                                                            } else {
                                                                                                
                                                                                                
                                                                                                char v79;
                                                                                                v79 = v4->ptr[10l];
                                                                                                
                                                                                                
                                                                                                bool v80;
                                                                                                v80 = v79 == 's';
                                                                                                
                                                                                                
                                                                                                bool v81;
                                                                                                v81 = v80 != true;
                                                                                                
                                                                                                
                                                                                                if (v81){
                                                                                                    
                                                                                                    StringDecref(v4); StringDecref(v5);
                                                                                                    return 24l;
                                                                                                } else {
                                                                                                    
                                                                                                    
                                                                                                    char v82;
                                                                                                    v82 = v4->ptr[17l];
                                                                                                    
                                                                                                    
                                                                                                    bool v83;
                                                                                                    v83 = v82 == '\n';
                                                                                                    
                                                                                                    
                                                                                                    bool v84;
                                                                                                    v84 = v83 != true;
                                                                                                    
                                                                                                    
                                                                                                    if (v84){
                                                                                                        
                                                                                                        StringDecref(v4); StringDecref(v5);
                                                                                                        return 25l;
                                                                                                    } else {
                                                                                                        
                                                                                                        
                                                                                                        char v85;
                                                                                                        v85 = v4->ptr[22l];
                                                                                                        
                                                                                                        StringDecref(v4);
                                                                                                        bool v86;
                                                                                                        v86 = v85 == 'd';
                                                                                                        
                                                                                                        
                                                                                                        bool v87;
                                                                                                        v87 = v86 != true;
                                                                                                        
                                                                                                        
                                                                                                        if (v87){
                                                                                                            
                                                                                                            StringDecref(v5);
                                                                                                            return 26l;
                                                                                                        } else {
                                                                                                            
                                                                                                            
                                                                                                            int32_t v88;
                                                                                                            v88 = v5->len-1;
                                                                                                            
                                                                                                            
                                                                                                            bool v89;
                                                                                                            v89 = v88 == 5l;
                                                                                                            
                                                                                                            
                                                                                                            bool v90;
                                                                                                            v90 = v89 != true;
                                                                                                            
                                                                                                            
                                                                                                            if (v90){
                                                                                                                
                                                                                                                StringDecref(v5);
                                                                                                                return 27l;
                                                                                                            } else {
                                                                                                                
                                                                                                                
                                                                                                                char v91;
                                                                                                                v91 = v5->ptr[3l];
                                                                                                                
                                                                                                                StringDecref(v5);
                                                                                                                bool v92;
                                                                                                                v92 = v91 == 'c';
                                                                                                                
                                                                                                                
                                                                                                                bool v93;
                                                                                                                v93 = v92 != true;
                                                                                                                
                                                                                                                
                                                                                                                if (v93){
                                                                                                                    
                                                                                                                    
                                                                                                                    return 28l;
                                                                                                                } else {
                                                                                                                    
                                                                                                                    
                                                                                                                    return 0l;
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
