#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
int32_t main(){
    
    
    int8_t v0;
    v0 = 100;
    
    
    int8_t v1;
    v1 = v0 + v0;
    
    
    uint8_t v2;
    v2 = 200u;
    
    
    uint8_t v3;
    v3 = 100u;
    
    
    uint8_t v4;
    v4 = v2 + v3;
    
    
    int8_t v5;
    v5 = -8;
    
    
    int8_t v6;
    v6 = v5 >> 1l;
    
    
    uint8_t v7;
    v7 = v2 >> 1l;
    
    
    int16_t v8;
    v8 = 20000;
    
    
    int16_t v9;
    v9 = v8 + v8;
    
    
    uint16_t v10;
    v10 = 40000u;
    
    
    uint16_t v11;
    v11 = v10 + v10;
    
    
    int32_t v12;
    v12 = 7l;
    
    
    int8_t v13;
    v13 = (int8_t)v12;
    
    
    int8_t v14;
    v14 = 9;
    
    
    int32_t v15;
    v15 = (int32_t)v14;
    
    
    bool v16;
    v16 = v1 == -56;
    
    
    bool v18;
    if (v16){
        
        
        bool v17;
        v17 = v4 == 44u;
        
        
        v18 = v17;
    } else {
        
        
        v18 = false;
    }
    
    
    bool v20;
    if (v18){
        
        
        bool v19;
        v19 = v6 == -4;
        
        
        v20 = v19;
    } else {
        
        
        v20 = false;
    }
    
    
    bool v22;
    if (v20){
        
        
        bool v21;
        v21 = v7 == 100u;
        
        
        v22 = v21;
    } else {
        
        
        v22 = false;
    }
    
    
    bool v24;
    if (v22){
        
        
        bool v23;
        v23 = v9 == -25536;
        
        
        v24 = v23;
    } else {
        
        
        v24 = false;
    }
    
    
    bool v26;
    if (v24){
        
        
        bool v25;
        v25 = v11 == 14464u;
        
        
        v26 = v25;
    } else {
        
        
        v26 = false;
    }
    
    
    bool v28;
    if (v26){
        
        
        bool v27;
        v27 = v13 == 7;
        
        
        v28 = v27;
    } else {
        
        
        v28 = false;
    }
    
    
    bool v30;
    if (v28){
        
        
        bool v29;
        v29 = v15 == 9l;
        
        
        v30 = v29;
    } else {
        
        
        v30 = false;
    }
    
    
    if (v30){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
