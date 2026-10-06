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
int32_t main(){
    
    
    String * v0;
    v0 = StringLit(8, "a \"b\" c");
    
    
    String * v1;
    v1 = StringLit(1, "");
    
    
    String * v2;
    v2 = StringLit(5, "a\\nb");
    
    
    String * v3;
    v3 = StringLit(84, "first\n(* not a comment *)\n// nor this\n\n$\"not a macro\" !x\ninl fake () = 1\n  indented");
    
    
    String * v4;
    v4 = StringLit(12, "\ntop\n\nlevel");
    
    
    int32_t v5;
    v5 = v0->len-1;
    
    
    bool v6;
    v6 = v5 == 7l;
    
    
    bool v7;
    v7 = v6 != true;
    
    
    if (v7){
        
        StringDecref(v0); StringDecref(v1); StringDecref(v2); StringDecref(v3); StringDecref(v4);
        return 1l;
    } else {
        
        
        char v8;
        v8 = v0->ptr[2l];
        
        StringDecref(v0);
        bool v9;
        v9 = v8 == '"';
        
        
        bool v10;
        v10 = v9 != true;
        
        
        if (v10){
            
            StringDecref(v1); StringDecref(v2); StringDecref(v3); StringDecref(v4);
            return 2l;
        } else {
            
            
            int32_t v11;
            v11 = v1->len-1;
            
            StringDecref(v1);
            bool v12;
            v12 = v11 == 0l;
            
            
            bool v13;
            v13 = v12 != true;
            
            
            if (v13){
                
                StringDecref(v2); StringDecref(v3); StringDecref(v4);
                return 3l;
            } else {
                
                
                int32_t v14;
                v14 = v2->len-1;
                
                
                bool v15;
                v15 = v14 == 4l;
                
                
                bool v16;
                v16 = v15 != true;
                
                
                if (v16){
                    
                    StringDecref(v2); StringDecref(v3); StringDecref(v4);
                    return 4l;
                } else {
                    
                    
                    char v17;
                    v17 = v2->ptr[1l];
                    
                    StringDecref(v2);
                    bool v18;
                    v18 = v17 == '\\';
                    
                    
                    bool v19;
                    v19 = v18 != true;
                    
                    
                    if (v19){
                        
                        StringDecref(v3); StringDecref(v4);
                        return 5l;
                    } else {
                        
                        
                        int32_t v20;
                        v20 = v3->len-1;
                        
                        
                        bool v21;
                        v21 = v20 == 83l;
                        
                        
                        bool v22;
                        v22 = v21 != true;
                        
                        
                        if (v22){
                            
                            StringDecref(v3); StringDecref(v4);
                            return 6l;
                        } else {
                            
                            
                            char v23;
                            v23 = v3->ptr[5l];
                            
                            
                            bool v24;
                            v24 = v23 == '\n';
                            
                            
                            bool v25;
                            v25 = v24 != true;
                            
                            
                            if (v25){
                                
                                StringDecref(v3); StringDecref(v4);
                                return 7l;
                            } else {
                                
                                
                                char v26;
                                v26 = v3->ptr[37l];
                                
                                
                                bool v27;
                                v27 = v26 == '\n';
                                
                                
                                bool v28;
                                v28 = v27 != true;
                                
                                
                                if (v28){
                                    
                                    StringDecref(v3); StringDecref(v4);
                                    return 8l;
                                } else {
                                    
                                    
                                    char v29;
                                    v29 = v3->ptr[38l];
                                    
                                    
                                    bool v30;
                                    v30 = v29 == '\n';
                                    
                                    
                                    bool v31;
                                    v31 = v30 != true;
                                    
                                    
                                    if (v31){
                                        
                                        StringDecref(v3); StringDecref(v4);
                                        return 9l;
                                    } else {
                                        
                                        
                                        char v32;
                                        v32 = v3->ptr[39l];
                                        
                                        
                                        bool v33;
                                        v33 = v32 == '$';
                                        
                                        
                                        bool v34;
                                        v34 = v33 != true;
                                        
                                        
                                        if (v34){
                                            
                                            StringDecref(v3); StringDecref(v4);
                                            return 10l;
                                        } else {
                                            
                                            
                                            char v35;
                                            v35 = v3->ptr[57l];
                                            
                                            
                                            bool v36;
                                            v36 = v35 == 'i';
                                            
                                            
                                            bool v37;
                                            v37 = v36 != true;
                                            
                                            
                                            if (v37){
                                                
                                                StringDecref(v3); StringDecref(v4);
                                                return 11l;
                                            } else {
                                                
                                                
                                                char v38;
                                                v38 = v3->ptr[82l];
                                                
                                                StringDecref(v3);
                                                bool v39;
                                                v39 = v38 == 'd';
                                                
                                                
                                                bool v40;
                                                v40 = v39 != true;
                                                
                                                
                                                if (v40){
                                                    
                                                    StringDecref(v4);
                                                    return 12l;
                                                } else {
                                                    
                                                    
                                                    int32_t v41;
                                                    v41 = v4->len-1;
                                                    
                                                    
                                                    bool v42;
                                                    v42 = v41 == 11l;
                                                    
                                                    
                                                    bool v43;
                                                    v43 = v42 != true;
                                                    
                                                    
                                                    if (v43){
                                                        
                                                        StringDecref(v4);
                                                        return 13l;
                                                    } else {
                                                        
                                                        
                                                        char v44;
                                                        v44 = v4->ptr[0l];
                                                        
                                                        
                                                        bool v45;
                                                        v45 = v44 == '\n';
                                                        
                                                        
                                                        bool v46;
                                                        v46 = v45 != true;
                                                        
                                                        
                                                        if (v46){
                                                            
                                                            StringDecref(v4);
                                                            return 14l;
                                                        } else {
                                                            
                                                            
                                                            char v47;
                                                            v47 = v4->ptr[5l];
                                                            
                                                            StringDecref(v4);
                                                            bool v48;
                                                            v48 = v47 == '\n';
                                                            
                                                            
                                                            bool v49;
                                                            v49 = v48 != true;
                                                            
                                                            
                                                            if (v49){
                                                                
                                                                
                                                                return 15l;
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
