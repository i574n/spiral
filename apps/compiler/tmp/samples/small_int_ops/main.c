#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
int32_t main(){
    
    
    int8_t v0;
    v0 = 100;
    
    
    int8_t v1;
    v1 = 3;
    
    
    int8_t v2;
    v2 = v0 * v1;
    
    
    int8_t v3;
    v3 = -8;
    
    
    int8_t v4;
    v4 = 2;
    
    
    int8_t v5;
    v5 = v3 / v4;
    
    
    int8_t v6;
    v6 = v3 % v1;
    
    
    int8_t v7;
    v7 = -v1;
    
    
    int8_t v8;
    v8 = v0 << 1l;
    
    
    uint8_t v9;
    v9 = 200u;
    
    
    uint8_t v10;
    v10 = 3u;
    
    
    uint8_t v11;
    v11 = v9 / v10;
    
    
    uint8_t v12;
    v12 = v9 % v10;
    
    
    uint8_t v13;
    v13 = 15u;
    
    
    uint8_t v14;
    v14 = v9 & v13;
    
    
    uint8_t v15;
    v15 = v9 | v13;
    
    
    uint8_t v16;
    v16 = v9 ^ v13;
    
    
    uint8_t v17;
    v17 = ~v13;
    
    
    int16_t v18;
    v18 = 20000;
    
    
    int16_t v19;
    v19 = 7;
    
    
    int16_t v20;
    v20 = v18 / v19;
    
    
    int16_t v21;
    v21 = v18 % v19;
    
    
    int16_t v22;
    v22 = -v18;
    
    
    uint16_t v23;
    v23 = 40000u;
    
    
    uint16_t v24;
    v24 = v23 << 1l;
    
    
    bool v25;
    v25 = v2 == 44;
    
    
    bool v27;
    if (v25){
        
        
        bool v26;
        v26 = v5 == -4;
        
        
        v27 = v26;
    } else {
        
        
        v27 = false;
    }
    
    
    bool v29;
    if (v27){
        
        
        bool v28;
        v28 = v6 == -2;
        
        
        v29 = v28;
    } else {
        
        
        v29 = false;
    }
    
    
    bool v31;
    if (v29){
        
        
        bool v30;
        v30 = v7 == -3;
        
        
        v31 = v30;
    } else {
        
        
        v31 = false;
    }
    
    
    bool v33;
    if (v31){
        
        
        bool v32;
        v32 = v8 == -56;
        
        
        v33 = v32;
    } else {
        
        
        v33 = false;
    }
    
    
    bool v35;
    if (v33){
        
        
        bool v34;
        v34 = v11 == 66u;
        
        
        v35 = v34;
    } else {
        
        
        v35 = false;
    }
    
    
    bool v37;
    if (v35){
        
        
        bool v36;
        v36 = v12 == 2u;
        
        
        v37 = v36;
    } else {
        
        
        v37 = false;
    }
    
    
    bool v39;
    if (v37){
        
        
        bool v38;
        v38 = v14 == 8u;
        
        
        v39 = v38;
    } else {
        
        
        v39 = false;
    }
    
    
    bool v41;
    if (v39){
        
        
        bool v40;
        v40 = v15 == 207u;
        
        
        v41 = v40;
    } else {
        
        
        v41 = false;
    }
    
    
    bool v43;
    if (v41){
        
        
        bool v42;
        v42 = v16 == 199u;
        
        
        v43 = v42;
    } else {
        
        
        v43 = false;
    }
    
    
    bool v45;
    if (v43){
        
        
        bool v44;
        v44 = v17 == 240u;
        
        
        v45 = v44;
    } else {
        
        
        v45 = false;
    }
    
    
    bool v47;
    if (v45){
        
        
        bool v46;
        v46 = v20 == 2857;
        
        
        v47 = v46;
    } else {
        
        
        v47 = false;
    }
    
    
    bool v49;
    if (v47){
        
        
        bool v48;
        v48 = v21 == 1;
        
        
        v49 = v48;
    } else {
        
        
        v49 = false;
    }
    
    
    bool v51;
    if (v49){
        
        
        bool v50;
        v50 = v22 == -20000;
        
        
        v51 = v50;
    } else {
        
        
        v51 = false;
    }
    
    
    bool v53;
    if (v51){
        
        
        bool v52;
        v52 = v24 == 14464u;
        
        
        v53 = v52;
    } else {
        
        
        v53 = false;
    }
    
    
    if (v53){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
