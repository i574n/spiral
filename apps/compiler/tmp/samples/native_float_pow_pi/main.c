#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
int32_t main(){
    
    
    float v0;
    v0 = 2.0f;
    
    
    float v1;
    v1 = 3.0f;
    
    
    double v2;
    v2 = 2.0;
    
    
    double v3;
    v3 = 3.0;
    
    
    float v4;
    v4 = 3.1415927f;
    
    
    double v5;
    v5 = 3.141592653589793;
    
    
    float v6;
    v6 = powf(v0,v1);
    
    
    bool v7;
    v7 = v6 == 8.0f;
    
    
    bool v10;
    if (v7){
        
        
        double v8;
        v8 = pow(v2,v3);
        
        
        bool v9;
        v9 = v8 == 8.0;
        
        
        v10 = v9;
    } else {
        
        
        v10 = false;
    }
    
    
    bool v12;
    if (v10){
        
        
        bool v11;
        v11 = v4 > 3.0f;
        
        
        v12 = v11;
    } else {
        
        
        v12 = false;
    }
    
    
    bool v14;
    if (v12){
        
        
        bool v13;
        v13 = v4 < 4.0f;
        
        
        v14 = v13;
    } else {
        
        
        v14 = false;
    }
    
    
    bool v16;
    if (v14){
        
        
        bool v15;
        v15 = v5 > 3.0;
        
        
        v16 = v15;
    } else {
        
        
        v16 = false;
    }
    
    
    bool v18;
    if (v16){
        
        
        bool v17;
        v17 = v5 < 4.0;
        
        
        v18 = v17;
    } else {
        
        
        v18 = false;
    }
    
    
    if (v18){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
