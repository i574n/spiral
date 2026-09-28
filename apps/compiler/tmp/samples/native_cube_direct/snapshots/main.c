#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
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
int32_t method2(){
    double v0;
    v0 = 0.0 - 5.0 ;
    double v1;
    v1 = 5.0 * 0.0 ;
    double v2;
    v2 = v1 * 0.0 ;
    double v3;
    v3 = v2 * 1.0 ;
    double v4;
    v4 = v0 * 1.0 ;
    double v5;
    v5 = v4 * 0.0 ;
    double v6;
    v6 = v5 * 1.0 ;
    double v7;
    v7 = v3 - v6 ;
    double v8;
    v8 = 5.0 * 1.0 ;
    double v9;
    v9 = v8 * 0.0 ;
    double v10;
    v10 = v7 + v9 ;
    double v11;
    v11 = v0 * 0.0 ;
    double v12;
    v12 = v11 * 0.0 ;
    double v13;
    v13 = v10 + v12 ;
    double v14;
    v14 = 5.0 * 1.0 ;
    double v15;
    v15 = v14 * 1.0 ;
    double v16;
    v16 = v13 + v15 ;
    double v17;
    v17 = 5.0 * 1.0 ;
    double v18;
    v18 = v17 * 1.0 ;
    double v19;
    v19 = v0 * 0.0 ;
    double v20;
    v20 = v19 * 1.0 ;
    double v21;
    v21 = v18 + v20 ;
    double v22;
    v22 = 5.0 * 0.0 ;
    double v23;
    v23 = v22 * 0.0 ;
    double v24;
    v24 = v23 * 0.0 ;
    double v25;
    v25 = v21 - v24 ;
    double v26;
    v26 = v0 * 1.0 ;
    double v27;
    v27 = v26 * 0.0 ;
    double v28;
    v28 = v27 * 0.0 ;
    double v29;
    v29 = v25 + v28 ;
    double v30;
    v30 = 5.0 * 1.0 ;
    double v31;
    v31 = v30 * 0.0 ;
    double v32;
    v32 = v29 - v31 ;
    double v33;
    v33 = v0 * 1.0 ;
    double v34;
    v34 = v33 * 1.0 ;
    double v35;
    v35 = 5.0 * 0.0 ;
    double v36;
    v36 = v35 * 1.0 ;
    double v37;
    v37 = v34 - v36 ;
    double v38;
    v38 = 5.0 * 0.0 ;
    double v39;
    v39 = v37 + v38 ;
    double v40;
    v40 = v39 + 100.0 ;
    double v41;
    v41 = 1.0 / v40 ;
    double v42;
    v42 = 160.0 / 2.0 ;
    double v43;
    v43 = v42 + 40.0 ;
    double v44;
    v44 = 40.0 * v41 ;
    double v45;
    v45 = v44 * v16 ;
    double v46;
    v46 = v45 * 2.0 ;
    double v47;
    v47 = v43 + v46 ;
    double v48;
    v48 = 44.0 / 2.0 ;
    double v49;
    v49 = 40.0 * v41 ;
    double v50;
    v50 = v49 * v32 ;
    double v51;
    v51 = v48 + v50 ;
    bool v52;
    v52 = v47 >= 0.0;
    bool v54;
    if (v52){
        bool v53;
        v53 = v47 < 160.0;
        v54 = v53;
    } else {
        v54 = false;
    }
    bool v56;
    if (v54){
        bool v55;
        v55 = v51 >= 0.0;
        v56 = v55;
    } else {
        v56 = false;
    }
    bool v58;
    if (v56){
        bool v57;
        v57 = v51 < 44.0;
        v58 = v57;
    } else {
        v58 = false;
    }
    US0 v61;
    if (v58){
        v61 = US0_1(v47, v51, v41);
    } else {
        v61 = US0_0();
    }
    switch (v61.tag) {
        case 1: { // Visible
            double v62 = v61.case1.v0; double v63 = v61.case1.v1; double v64 = v61.case1.v2;
            USDecref0(&(v61));
            bool v65;
            v65 = v62 >= 0.0;
            bool v67;
            if (v65){
                bool v66;
                v66 = v63 >= 0.0;
                v67 = v66;
            } else {
                v67 = false;
            }
            bool v69;
            if (v67){
                bool v68;
                v68 = v64 > 0.0;
                v69 = v68;
            } else {
                v69 = false;
            }
            if (v69){
                return 14l;
            } else {
                return 0l;
            }
            break;
        }
        default: {
            USDecref0(&(v61));
            return 0l;
        }
    }
}
int32_t method1(){
    double v0;
    v0 = 0.0 - 10.0 ;
    double v1;
    v1 = 10.0 * 0.0 ;
    double v2;
    v2 = v1 * 0.0 ;
    double v3;
    v3 = v2 * 1.0 ;
    double v4;
    v4 = v0 * 1.0 ;
    double v5;
    v5 = v4 * 0.0 ;
    double v6;
    v6 = v5 * 1.0 ;
    double v7;
    v7 = v3 - v6 ;
    double v8;
    v8 = 10.0 * 1.0 ;
    double v9;
    v9 = v8 * 0.0 ;
    double v10;
    v10 = v7 + v9 ;
    double v11;
    v11 = v0 * 0.0 ;
    double v12;
    v12 = v11 * 0.0 ;
    double v13;
    v13 = v10 + v12 ;
    double v14;
    v14 = 10.0 * 1.0 ;
    double v15;
    v15 = v14 * 1.0 ;
    double v16;
    v16 = v13 + v15 ;
    double v17;
    v17 = 10.0 * 1.0 ;
    double v18;
    v18 = v17 * 1.0 ;
    double v19;
    v19 = v0 * 0.0 ;
    double v20;
    v20 = v19 * 1.0 ;
    double v21;
    v21 = v18 + v20 ;
    double v22;
    v22 = 10.0 * 0.0 ;
    double v23;
    v23 = v22 * 0.0 ;
    double v24;
    v24 = v23 * 0.0 ;
    double v25;
    v25 = v21 - v24 ;
    double v26;
    v26 = v0 * 1.0 ;
    double v27;
    v27 = v26 * 0.0 ;
    double v28;
    v28 = v27 * 0.0 ;
    double v29;
    v29 = v25 + v28 ;
    double v30;
    v30 = 10.0 * 1.0 ;
    double v31;
    v31 = v30 * 0.0 ;
    double v32;
    v32 = v29 - v31 ;
    double v33;
    v33 = v0 * 1.0 ;
    double v34;
    v34 = v33 * 1.0 ;
    double v35;
    v35 = 10.0 * 0.0 ;
    double v36;
    v36 = v35 * 1.0 ;
    double v37;
    v37 = v34 - v36 ;
    double v38;
    v38 = 10.0 * 0.0 ;
    double v39;
    v39 = v37 + v38 ;
    double v40;
    v40 = v39 + 100.0 ;
    double v41;
    v41 = 1.0 / v40 ;
    double v42;
    v42 = 160.0 / 2.0 ;
    double v43;
    v43 = v42 + 10.0 ;
    double v44;
    v44 = 40.0 * v41 ;
    double v45;
    v45 = v44 * v16 ;
    double v46;
    v46 = v45 * 2.0 ;
    double v47;
    v47 = v43 + v46 ;
    double v48;
    v48 = 44.0 / 2.0 ;
    double v49;
    v49 = 40.0 * v41 ;
    double v50;
    v50 = v49 * v32 ;
    double v51;
    v51 = v48 + v50 ;
    bool v52;
    v52 = v47 >= 0.0;
    bool v54;
    if (v52){
        bool v53;
        v53 = v47 < 160.0;
        v54 = v53;
    } else {
        v54 = false;
    }
    bool v56;
    if (v54){
        bool v55;
        v55 = v51 >= 0.0;
        v56 = v55;
    } else {
        v56 = false;
    }
    bool v58;
    if (v56){
        bool v57;
        v57 = v51 < 44.0;
        v58 = v57;
    } else {
        v58 = false;
    }
    US0 v61;
    if (v58){
        v61 = US0_1(v47, v51, v41);
    } else {
        v61 = US0_0();
    }
    int32_t v71;
    switch (v61.tag) {
        case 1: { // Visible
            double v62 = v61.case1.v0; double v63 = v61.case1.v1; double v64 = v61.case1.v2;
            bool v65;
            v65 = v62 >= 0.0;
            bool v67;
            if (v65){
                bool v66;
                v66 = v63 >= 0.0;
                v67 = v66;
            } else {
                v67 = false;
            }
            bool v69;
            if (v67){
                bool v68;
                v68 = v64 > 0.0;
                v69 = v68;
            } else {
                v69 = false;
            }
            if (v69){
                v71 = 14l;
            } else {
                v71 = 0l;
            }
            break;
        }
        default: {
            v71 = 0l;
        }
    }
    USDecref0(&(v61));
    int32_t v72;
    v72 = method2();
    int32_t v73;
    v73 = v71 + v72 ;
    return v73;
}
int32_t method0(){
    double v0;
    v0 = 0.0 - 40.0 ;
    double v1;
    v1 = 0.0 - 20.0 ;
    double v2;
    v2 = 20.0 * 0.0 ;
    double v3;
    v3 = v2 * 0.0 ;
    double v4;
    v4 = v3 * 1.0 ;
    double v5;
    v5 = v1 * 1.0 ;
    double v6;
    v6 = v5 * 0.0 ;
    double v7;
    v7 = v6 * 1.0 ;
    double v8;
    v8 = v4 - v7 ;
    double v9;
    v9 = 20.0 * 1.0 ;
    double v10;
    v10 = v9 * 0.0 ;
    double v11;
    v11 = v8 + v10 ;
    double v12;
    v12 = v1 * 0.0 ;
    double v13;
    v13 = v12 * 0.0 ;
    double v14;
    v14 = v11 + v13 ;
    double v15;
    v15 = 20.0 * 1.0 ;
    double v16;
    v16 = v15 * 1.0 ;
    double v17;
    v17 = v14 + v16 ;
    double v18;
    v18 = 20.0 * 1.0 ;
    double v19;
    v19 = v18 * 1.0 ;
    double v20;
    v20 = v1 * 0.0 ;
    double v21;
    v21 = v20 * 1.0 ;
    double v22;
    v22 = v19 + v21 ;
    double v23;
    v23 = 20.0 * 0.0 ;
    double v24;
    v24 = v23 * 0.0 ;
    double v25;
    v25 = v24 * 0.0 ;
    double v26;
    v26 = v22 - v25 ;
    double v27;
    v27 = v1 * 1.0 ;
    double v28;
    v28 = v27 * 0.0 ;
    double v29;
    v29 = v28 * 0.0 ;
    double v30;
    v30 = v26 + v29 ;
    double v31;
    v31 = 20.0 * 1.0 ;
    double v32;
    v32 = v31 * 0.0 ;
    double v33;
    v33 = v30 - v32 ;
    double v34;
    v34 = v1 * 1.0 ;
    double v35;
    v35 = v34 * 1.0 ;
    double v36;
    v36 = 20.0 * 0.0 ;
    double v37;
    v37 = v36 * 1.0 ;
    double v38;
    v38 = v35 - v37 ;
    double v39;
    v39 = 20.0 * 0.0 ;
    double v40;
    v40 = v38 + v39 ;
    double v41;
    v41 = v40 + 100.0 ;
    double v42;
    v42 = 1.0 / v41 ;
    double v43;
    v43 = 160.0 / 2.0 ;
    double v44;
    v44 = v43 + v0 ;
    double v45;
    v45 = 40.0 * v42 ;
    double v46;
    v46 = v45 * v17 ;
    double v47;
    v47 = v46 * 2.0 ;
    double v48;
    v48 = v44 + v47 ;
    double v49;
    v49 = 44.0 / 2.0 ;
    double v50;
    v50 = 40.0 * v42 ;
    double v51;
    v51 = v50 * v33 ;
    double v52;
    v52 = v49 + v51 ;
    bool v53;
    v53 = v48 >= 0.0;
    bool v55;
    if (v53){
        bool v54;
        v54 = v48 < 160.0;
        v55 = v54;
    } else {
        v55 = false;
    }
    bool v57;
    if (v55){
        bool v56;
        v56 = v52 >= 0.0;
        v57 = v56;
    } else {
        v57 = false;
    }
    bool v59;
    if (v57){
        bool v58;
        v58 = v52 < 44.0;
        v59 = v58;
    } else {
        v59 = false;
    }
    US0 v62;
    if (v59){
        v62 = US0_1(v48, v52, v42);
    } else {
        v62 = US0_0();
    }
    int32_t v72;
    switch (v62.tag) {
        case 1: { // Visible
            double v63 = v62.case1.v0; double v64 = v62.case1.v1; double v65 = v62.case1.v2;
            bool v66;
            v66 = v63 >= 0.0;
            bool v68;
            if (v66){
                bool v67;
                v67 = v64 >= 0.0;
                v68 = v67;
            } else {
                v68 = false;
            }
            bool v70;
            if (v68){
                bool v69;
                v69 = v65 > 0.0;
                v70 = v69;
            } else {
                v70 = false;
            }
            if (v70){
                v72 = 14l;
            } else {
                v72 = 0l;
            }
            break;
        }
        default: {
            v72 = 0l;
        }
    }
    USDecref0(&(v62));
    int32_t v73;
    v73 = method1();
    int32_t v74;
    v74 = v72 + v73 ;
    return v74;
}
int32_t main(){
    return method0();
}
