#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
#include <poll.h>
typedef struct {
    int refc;
    uint32_t len;
    int32_t ptr[];
} Array0;
typedef struct {
    int tag;
    union {
        struct {
            double v0;
            double v1;
            double v2;
        } case1; // Visible
    };
} US0;
typedef struct {
    int refc;
    uint32_t len;
    char ptr[];
} Array1;
typedef Array1 String;
static inline void ArrayDecrefBody0(Array0 * x){
}
void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(int32_t) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array0 * ArrayLit0(uint32_t len, int32_t * ptr){
    Array0 * x = ArrayCreate0(len, false);
    memcpy(x->ptr, ptr, sizeof(int32_t) * len);
    return x;
}
bool method_while0(int32_t v0){
    bool v1;
    v1 = v0 < 3l;
    return v1;
}
bool method_while1(int32_t v0, int32_t v1){
    bool v2;
    v2 = v1 < v0;
    return v2;
}
static inline void AssignArray0(int32_t * a, int32_t b){
    *a = b;
}
static inline void USIncrefBody0(US0 * x){
    switch (x->tag) {
    }
}
static inline void USDecrefBody0(US0 * x){
    switch (x->tag) {
    }
}
void USIncref0(US0 * x){ USIncrefBody0(x); }
void USDecref0(US0 * x){ USDecrefBody0(x); }
US0 US0_0() { // Hidden
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_1(double v0, double v1, double v2) { // Visible
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0; x.case1.v1 = v1; x.case1.v2 = v2;
    return x;
}
int32_t method0(Array0 * v0, double v1, double v2, double v3){
    double v4;
    v4 = 0.0 - 40.0 ;
    double v5;
    v5 = 0.0 - 20.0 ;
    double v6;
    v6 = sin(v1);
    double v7;
    v7 = 20.0 * v6 ;
    double v8;
    v8 = sin(v2);
    double v9;
    v9 = v7 * v8 ;
    double v10;
    v10 = cos(v3);
    double v11;
    v11 = v9 * v10 ;
    double v12;
    v12 = cos(v1);
    double v13;
    v13 = v5 * v12 ;
    double v14;
    v14 = v13 * v8 ;
    double v15;
    v15 = v14 * v10 ;
    double v16;
    v16 = v11 - v15 ;
    double v17;
    v17 = 20.0 * v12 ;
    double v18;
    v18 = sin(v3);
    double v19;
    v19 = v17 * v18 ;
    double v20;
    v20 = v16 + v19 ;
    double v21;
    v21 = v5 * v6 ;
    double v22;
    v22 = v21 * v18 ;
    double v23;
    v23 = v20 + v22 ;
    double v24;
    v24 = cos(v2);
    double v25;
    v25 = 20.0 * v24 ;
    double v26;
    v26 = v25 * v10 ;
    double v27;
    v27 = v23 + v26 ;
    double v28;
    v28 = 20.0 * v12 ;
    double v29;
    v29 = v28 * v10 ;
    double v30;
    v30 = v5 * v6 ;
    double v31;
    v31 = v30 * v10 ;
    double v32;
    v32 = v29 + v31 ;
    double v33;
    v33 = 20.0 * v6 ;
    double v34;
    v34 = v33 * v8 ;
    double v35;
    v35 = v34 * v18 ;
    double v36;
    v36 = v32 - v35 ;
    double v37;
    v37 = v5 * v12 ;
    double v38;
    v38 = v37 * v8 ;
    double v39;
    v39 = v38 * v18 ;
    double v40;
    v40 = v36 + v39 ;
    double v41;
    v41 = 20.0 * v24 ;
    double v42;
    v42 = v41 * v18 ;
    double v43;
    v43 = v40 - v42 ;
    double v44;
    v44 = v5 * v12 ;
    double v45;
    v45 = v44 * v24 ;
    double v46;
    v46 = 20.0 * v6 ;
    double v47;
    v47 = v46 * v24 ;
    double v48;
    v48 = v45 - v47 ;
    double v49;
    v49 = 20.0 * v8 ;
    double v50;
    v50 = v48 + v49 ;
    double v51;
    v51 = v50 + 100.0 ;
    double v52;
    v52 = 1.0 / v51 ;
    double v53;
    v53 = 80.0 + v4 ;
    double v54;
    v54 = 40.0 * v52 ;
    double v55;
    v55 = v54 * v27 ;
    double v56;
    v56 = v55 * 2.0 ;
    double v57;
    v57 = v53 + v56 ;
    double v58;
    v58 = 40.0 * v52 ;
    double v59;
    v59 = v58 * v43 ;
    double v60;
    v60 = 22.0 + v59 ;
    bool v61;
    v61 = v57 >= 0.0;
    bool v63;
    if (v61){
        bool v62;
        v62 = v57 < 160.0;
        v63 = v62;
    } else {
        v63 = false;
    }
    bool v65;
    if (v63){
        bool v64;
        v64 = v60 >= 0.0;
        v65 = v64;
    } else {
        v65 = false;
    }
    bool v67;
    if (v65){
        bool v66;
        v66 = v60 < 44.0;
        v67 = v66;
    } else {
        v67 = false;
    }
    US0 v70;
    if (v67){
        v70 = US0_1(v57, v60, v52);
    } else {
        v70 = US0_0();
    }
    switch (v70.tag) {
        case 1: { // Visible
            double v71 = v70.case1.v0; double v72 = v70.case1.v1; double v73 = v70.case1.v2;
            USDecref0(&(v70));
            bool v74;
            v74 = v71 >= 0.0;
            bool v76;
            if (v74){
                bool v75;
                v75 = v72 >= 0.0;
                v76 = v75;
            } else {
                v76 = false;
            }
            bool v78;
            if (v76){
                bool v77;
                v77 = v73 > 0.0;
                v78 = v77;
            } else {
                v78 = false;
            }
            if (v78){
                int32_t v79;
                v79 = (int32_t)v71;
                int32_t v80;
                v80 = (int32_t)v72;
                int32_t v81;
                v81 = v80 * 160l ;
                int32_t v82;
                v82 = v79 + v81 ;
                AssignArray0(&(v0->ptr[v82]), 35l);
                ArrayDecref0(v0);
                return v82;
            } else {
                ArrayDecref0(v0);
                return 0l;
            }
            break;
        }
        default: {
            ArrayDecref0(v0); USDecref0(&(v70));
            return 0l;
        }
    }
}
int32_t method1(Array0 * v0, double v1, double v2, double v3){
    double v4;
    v4 = 0.0 - 10.0 ;
    double v5;
    v5 = sin(v1);
    double v6;
    v6 = 10.0 * v5 ;
    double v7;
    v7 = sin(v2);
    double v8;
    v8 = v6 * v7 ;
    double v9;
    v9 = cos(v3);
    double v10;
    v10 = v8 * v9 ;
    double v11;
    v11 = cos(v1);
    double v12;
    v12 = v4 * v11 ;
    double v13;
    v13 = v12 * v7 ;
    double v14;
    v14 = v13 * v9 ;
    double v15;
    v15 = v10 - v14 ;
    double v16;
    v16 = 10.0 * v11 ;
    double v17;
    v17 = sin(v3);
    double v18;
    v18 = v16 * v17 ;
    double v19;
    v19 = v15 + v18 ;
    double v20;
    v20 = v4 * v5 ;
    double v21;
    v21 = v20 * v17 ;
    double v22;
    v22 = v19 + v21 ;
    double v23;
    v23 = cos(v2);
    double v24;
    v24 = 10.0 * v23 ;
    double v25;
    v25 = v24 * v9 ;
    double v26;
    v26 = v22 + v25 ;
    double v27;
    v27 = 10.0 * v11 ;
    double v28;
    v28 = v27 * v9 ;
    double v29;
    v29 = v4 * v5 ;
    double v30;
    v30 = v29 * v9 ;
    double v31;
    v31 = v28 + v30 ;
    double v32;
    v32 = 10.0 * v5 ;
    double v33;
    v33 = v32 * v7 ;
    double v34;
    v34 = v33 * v17 ;
    double v35;
    v35 = v31 - v34 ;
    double v36;
    v36 = v4 * v11 ;
    double v37;
    v37 = v36 * v7 ;
    double v38;
    v38 = v37 * v17 ;
    double v39;
    v39 = v35 + v38 ;
    double v40;
    v40 = 10.0 * v23 ;
    double v41;
    v41 = v40 * v17 ;
    double v42;
    v42 = v39 - v41 ;
    double v43;
    v43 = v4 * v11 ;
    double v44;
    v44 = v43 * v23 ;
    double v45;
    v45 = 10.0 * v5 ;
    double v46;
    v46 = v45 * v23 ;
    double v47;
    v47 = v44 - v46 ;
    double v48;
    v48 = 10.0 * v7 ;
    double v49;
    v49 = v47 + v48 ;
    double v50;
    v50 = v49 + 100.0 ;
    double v51;
    v51 = 1.0 / v50 ;
    double v52;
    v52 = 80.0 + 10.0 ;
    double v53;
    v53 = 40.0 * v51 ;
    double v54;
    v54 = v53 * v26 ;
    double v55;
    v55 = v54 * 2.0 ;
    double v56;
    v56 = v52 + v55 ;
    double v57;
    v57 = 40.0 * v51 ;
    double v58;
    v58 = v57 * v42 ;
    double v59;
    v59 = 22.0 + v58 ;
    bool v60;
    v60 = v56 >= 0.0;
    bool v62;
    if (v60){
        bool v61;
        v61 = v56 < 160.0;
        v62 = v61;
    } else {
        v62 = false;
    }
    bool v64;
    if (v62){
        bool v63;
        v63 = v59 >= 0.0;
        v64 = v63;
    } else {
        v64 = false;
    }
    bool v66;
    if (v64){
        bool v65;
        v65 = v59 < 44.0;
        v66 = v65;
    } else {
        v66 = false;
    }
    US0 v69;
    if (v66){
        v69 = US0_1(v56, v59, v51);
    } else {
        v69 = US0_0();
    }
    switch (v69.tag) {
        case 1: { // Visible
            double v70 = v69.case1.v0; double v71 = v69.case1.v1; double v72 = v69.case1.v2;
            USDecref0(&(v69));
            bool v73;
            v73 = v70 >= 0.0;
            bool v75;
            if (v73){
                bool v74;
                v74 = v71 >= 0.0;
                v75 = v74;
            } else {
                v75 = false;
            }
            bool v77;
            if (v75){
                bool v76;
                v76 = v72 > 0.0;
                v77 = v76;
            } else {
                v77 = false;
            }
            if (v77){
                int32_t v78;
                v78 = (int32_t)v70;
                int32_t v79;
                v79 = (int32_t)v71;
                int32_t v80;
                v80 = v79 * 160l ;
                int32_t v81;
                v81 = v78 + v80 ;
                AssignArray0(&(v0->ptr[v81]), 64l);
                ArrayDecref0(v0);
                return v81;
            } else {
                ArrayDecref0(v0);
                return 0l;
            }
            break;
        }
        default: {
            ArrayDecref0(v0); USDecref0(&(v69));
            return 0l;
        }
    }
}
int32_t method2(Array0 * v0, double v1, double v2, double v3){
    double v4;
    v4 = 0.0 - 5.0 ;
    double v5;
    v5 = sin(v1);
    double v6;
    v6 = 5.0 * v5 ;
    double v7;
    v7 = sin(v2);
    double v8;
    v8 = v6 * v7 ;
    double v9;
    v9 = cos(v3);
    double v10;
    v10 = v8 * v9 ;
    double v11;
    v11 = cos(v1);
    double v12;
    v12 = v4 * v11 ;
    double v13;
    v13 = v12 * v7 ;
    double v14;
    v14 = v13 * v9 ;
    double v15;
    v15 = v10 - v14 ;
    double v16;
    v16 = 5.0 * v11 ;
    double v17;
    v17 = sin(v3);
    double v18;
    v18 = v16 * v17 ;
    double v19;
    v19 = v15 + v18 ;
    double v20;
    v20 = v4 * v5 ;
    double v21;
    v21 = v20 * v17 ;
    double v22;
    v22 = v19 + v21 ;
    double v23;
    v23 = cos(v2);
    double v24;
    v24 = 5.0 * v23 ;
    double v25;
    v25 = v24 * v9 ;
    double v26;
    v26 = v22 + v25 ;
    double v27;
    v27 = 5.0 * v11 ;
    double v28;
    v28 = v27 * v9 ;
    double v29;
    v29 = v4 * v5 ;
    double v30;
    v30 = v29 * v9 ;
    double v31;
    v31 = v28 + v30 ;
    double v32;
    v32 = 5.0 * v5 ;
    double v33;
    v33 = v32 * v7 ;
    double v34;
    v34 = v33 * v17 ;
    double v35;
    v35 = v31 - v34 ;
    double v36;
    v36 = v4 * v11 ;
    double v37;
    v37 = v36 * v7 ;
    double v38;
    v38 = v37 * v17 ;
    double v39;
    v39 = v35 + v38 ;
    double v40;
    v40 = 5.0 * v23 ;
    double v41;
    v41 = v40 * v17 ;
    double v42;
    v42 = v39 - v41 ;
    double v43;
    v43 = v4 * v11 ;
    double v44;
    v44 = v43 * v23 ;
    double v45;
    v45 = 5.0 * v5 ;
    double v46;
    v46 = v45 * v23 ;
    double v47;
    v47 = v44 - v46 ;
    double v48;
    v48 = 5.0 * v7 ;
    double v49;
    v49 = v47 + v48 ;
    double v50;
    v50 = v49 + 100.0 ;
    double v51;
    v51 = 1.0 / v50 ;
    double v52;
    v52 = 80.0 + 40.0 ;
    double v53;
    v53 = 40.0 * v51 ;
    double v54;
    v54 = v53 * v26 ;
    double v55;
    v55 = v54 * 2.0 ;
    double v56;
    v56 = v52 + v55 ;
    double v57;
    v57 = 40.0 * v51 ;
    double v58;
    v58 = v57 * v42 ;
    double v59;
    v59 = 22.0 + v58 ;
    bool v60;
    v60 = v56 >= 0.0;
    bool v62;
    if (v60){
        bool v61;
        v61 = v56 < 160.0;
        v62 = v61;
    } else {
        v62 = false;
    }
    bool v64;
    if (v62){
        bool v63;
        v63 = v59 >= 0.0;
        v64 = v63;
    } else {
        v64 = false;
    }
    bool v66;
    if (v64){
        bool v65;
        v65 = v59 < 44.0;
        v66 = v65;
    } else {
        v66 = false;
    }
    US0 v69;
    if (v66){
        v69 = US0_1(v56, v59, v51);
    } else {
        v69 = US0_0();
    }
    switch (v69.tag) {
        case 1: { // Visible
            double v70 = v69.case1.v0; double v71 = v69.case1.v1; double v72 = v69.case1.v2;
            USDecref0(&(v69));
            bool v73;
            v73 = v70 >= 0.0;
            bool v75;
            if (v73){
                bool v74;
                v74 = v71 >= 0.0;
                v75 = v74;
            } else {
                v75 = false;
            }
            bool v77;
            if (v75){
                bool v76;
                v76 = v72 > 0.0;
                v77 = v76;
            } else {
                v77 = false;
            }
            if (v77){
                int32_t v78;
                v78 = (int32_t)v70;
                int32_t v79;
                v79 = (int32_t)v71;
                int32_t v80;
                v80 = v79 * 160l ;
                int32_t v81;
                v81 = v78 + v80 ;
                AssignArray0(&(v0->ptr[v81]), 43l);
                ArrayDecref0(v0);
                return v81;
            } else {
                ArrayDecref0(v0);
                return 0l;
            }
            break;
        }
        default: {
            ArrayDecref0(v0); USDecref0(&(v69));
            return 0l;
        }
    }
}
static inline void ArrayDecrefBody1(Array1 * x){
}
void ArrayDecref1(Array1 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody1(x); free(x); }
}
Array1 * ArrayCreate1(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array1) + sizeof(char) * len;
    Array1 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array1 * ArrayLit1(uint32_t len, char * ptr){
    Array1 * x = ArrayCreate1(len, false);
    memcpy(x->ptr, ptr, sizeof(char) * len);
    return x;
}
static inline void StringDecref(String * x){
    return ArrayDecref1(x);
}
static inline String * StringLit(uint32_t len, char * ptr){
    return ArrayLit1(len, ptr);
}
static inline String * StringConcat(String * left, String * right){
    uint32_t left_len = left->len - 1;
    uint32_t right_len = right->len - 1;
    String * result = ArrayCreate1(left_len + right_len + 1, false);
    memcpy(result->ptr, left->ptr, left_len);
    memcpy(result->ptr + left_len, right->ptr, right_len + 1);
    return result;
}
String * frame_text_loop3(Array0 * v0, int32_t v1, int32_t v2, int32_t v3, String * v4){
    bool v5;
    v5 = v3 == v2 ;
    if (v5){
        ArrayDecref0(v0);
        return v4;
    } else {
        int32_t v6;
        v6 = v0->ptr[v3];
        bool v7;
        v7 = v6 == 35l ;
        String * v16;
        if (v7){
            String * v8;
            v8 = StringLit(2, "#");
            v16 = v8;
        } else {
            bool v9;
            v9 = v6 == 43l ;
            if (v9){
                String * v10;
                v10 = StringLit(2, "+");
                v16 = v10;
            } else {
                bool v11;
                v11 = v6 == 64l ;
                if (v11){
                    String * v12;
                    v12 = StringLit(2, "@");
                    v16 = v12;
                } else {
                    String * v13;
                    v13 = StringLit(2, ".");
                    v16 = v13;
                }
            }
        }
        String * v17;
        v17 = StringConcat(v4, v16);
        StringDecref(v4); StringDecref(v16);
        int32_t v18;
        v18 = v3 + 1l ;
        int32_t v19;
        v19 = v3 % v1 ;
        int32_t v20;
        v20 = v1 - 1l ;
        bool v21;
        v21 = v19 == v20 ;
        bool v23;
        if (v21){
            bool v22;
            v22 = v18 < v2;
            v23 = v22;
        } else {
            v23 = false;
        }
        if (v23){
            String * v24;
            v24 = StringConcat(v17, StringLit(2, "\n"));
            StringDecref(v17);
            return frame_text_loop3(v0, v1, v2, v18, v24);
        } else {
            return frame_text_loop3(v0, v1, v2, v18, v17);
        }
    }
}
char runtime_byte6(String * v0, int32_t v1){
    char v2;
    v2 = v0->ptr[v1];
    StringDecref(v0);
    return v2;
}
int32_t utf8_scalar_at_byte_offset5(String * v0, int32_t v1){
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
            v7 = runtime_byte6(v0, v1);
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
                            v17 = runtime_byte6(v0, v16);
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
                                v34 = runtime_byte6(v0, v33);
                                int32_t v35;
                                v35 = ((uint8_t)v34);
                                int32_t v36;
                                v36 = v1 + 2l ;
                                v0->refc++;
                                char v37;
                                v37 = runtime_byte6(v0, v36);
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
                                    v70 = runtime_byte6(v0, v69);
                                    int32_t v71;
                                    v71 = ((uint8_t)v70);
                                    int32_t v72;
                                    v72 = v1 + 2l ;
                                    v0->refc++;
                                    char v73;
                                    v73 = runtime_byte6(v0, v72);
                                    int32_t v74;
                                    v74 = ((uint8_t)v73);
                                    int32_t v75;
                                    v75 = v1 + 3l ;
                                    v0->refc++;
                                    char v76;
                                    v76 = runtime_byte6(v0, v75);
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
int32_t loop4(String * v0, int32_t v1, int32_t v2, int32_t v3){
    bool v4;
    v4 = v2 == v1 ;
    if (v4){
        StringDecref(v0);
        return v3;
    } else {
        bool v5;
        v5 = v2 > v1;
        if (v5){
            StringDecref(v0);
            fprintf(stderr, "%s\n", "UTF-8 scalar width exceeds the string.");
            exit(EXIT_FAILURE);
        } else {
            v0->refc++;
            int32_t v7;
            v7 = utf8_scalar_at_byte_offset5(v0, v2);
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
            int32_t v14;
            v14 = v2 + v13 ;
            int32_t v15;
            v15 = v3 + v7 ;
            return loop4(v0, v1, v14, v15);
        }
    }
}
bool method_while2(int32_t v0){
    bool v1;
    v1 = v0 < 4096l;
    return v1;
}
int32_t main(){
    int32_t v0;
    v0 = 160l * 44l ;
    Array0 * v1;
    v1 = ArrayCreate0(v0, false);
    Array0 * v2;
    v2 = ArrayCreate0(3l, false);
    int32_t v3;
    v3 = 0l;
    int32_t v4;
    v4 = 0l;
    while (method_while0(v4)){
        bool v6;
        v6 = v4 == 0l ;
        double v11; double v12; double v13;
        if (v6){
            v11 = 0.0; v12 = 0.0; v13 = 0.0;
        } else {
            bool v7;
            v7 = v4 == 1l ;
            if (v7){
                v11 = 0.1; v12 = 0.05; v13 = 0.02;
            } else {
                v11 = 0.2; v12 = 0.1; v13 = 0.04;
            }
        }
        int32_t v14;
        v14 = 160l * 44l ;
        int32_t v15;
        v15 = 0l;
        while (method_while1(v14, v15)){
            AssignArray0(&(v1->ptr[v15]), 46l);
            int32_t v17;
            v17 = v15 + 1l ;
            v15 = v17;
        }
        v1->refc++;
        int32_t v18;
        v18 = method0(v1, v11, v12, v13);
        v1->refc++;
        int32_t v19;
        v19 = method1(v1, v11, v12, v13);
        v1->refc++;
        int32_t v20;
        v20 = method2(v1, v11, v12, v13);
        int32_t v21;
        v21 = 160l;
        int32_t v22;
        v22 = 160l * 44l ;
        int32_t v23;
        v23 = 0l;
        String * v24;
        v24 = StringLit(1, "");
        v1->refc++; v24->refc++;
        String * v25;
        v25 = frame_text_loop3(v1, v21, v22, v23, v24);
        StringDecref(v24);
        int32_t v26;
        v26 = v25->len-1;
        int32_t v27;
        v27 = 0l;
        int32_t v28;
        v28 = 0l;
        v25->refc++;
        int32_t v29;
        v29 = loop4(v25, v26, v27, v28);
        String * v30;
        v30 = StringConcat(StringLit(4, "[H"), v25);
        StringDecref(v25);
        printf("%s", v30->ptr);
        StringDecref(v30);
        int32_t v31;
        v31 = v19 * 3l ;
        int32_t v32;
        v32 = v18 + v31 ;
        int32_t v33;
        v33 = v20 * 7l ;
        int32_t v34;
        v34 = v32 + v33 ;
        bool v35;
        v35 = v26 == 7083l ;
        bool v37;
        if (v35){
            bool v36;
            v36 = v29 == 324274l ;
            v37 = v36;
        } else {
            v37 = false;
        }
        int32_t v38;
        if (v37){
            v38 = v34;
        } else {
            v38 = 0l;
        }
        AssignArray0(&(v2->ptr[v4]), v38);
        bool v39;
        v39 = v4 < 2l;
        if (v39){
            int32_t v40;
            v40 = 0l;
            int32_t v41;
            v41 = v4 + 1l ;
            while (method_while2(v40)){
                int32_t v43;
                v43 = v40 % 17l ;
                int32_t v44;
                v44 = v41 + v43 ;
                int32_t v45;
                v45 = v44 + 1l ;
                int32_t v46;
                v46 = v45 % 997l ;
                v41 = v46;
                int32_t v47;
                v47 = v40 + 1l ;
                v40 = v47;
            }
            int32_t v48;
            v48 = v3 + v41 ;
            v3 = v48;
            poll(0, 0, 25l);
        } else {
        }
        int32_t v49;
        v49 = v4 + 1l ;
        v4 = v49;
    }
    ArrayDecref0(v1);
    int32_t v50;
    v50 = v2->ptr[0l];
    int32_t v51;
    v51 = v2->ptr[1l];
    int32_t v52;
    v52 = v2->ptr[2l];
    ArrayDecref0(v2);
    bool v53;
    v53 = v50 == 45702l ;
    bool v55;
    if (v53){
        bool v54;
        v54 = v51 == 43786l ;
        v55 = v54;
    } else {
        v55 = false;
    }
    bool v57;
    if (v55){
        bool v56;
        v56 = v52 == 43631l ;
        v57 = v56;
    } else {
        v57 = false;
    }
    bool v59;
    if (v57){
        bool v58;
        v58 = v3 == 1931l ;
        v59 = v58;
    } else {
        v59 = false;
    }
    if (v59){
        return 42l;
    } else {
        return 1l;
    }
}
