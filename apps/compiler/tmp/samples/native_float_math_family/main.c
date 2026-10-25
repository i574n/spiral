#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
int32_t main(){
    
    
    float v0;
    v0 = 0.0f;
    
    
    float v1;
    v1 = 1.0f;
    
    
    double v2;
    v2 = 0.0;
    
    
    double v3;
    v3 = 1.0;
    
    
    float v4;
    v4 = logf(v1);
    
    
    bool v5;
    v5 = v4 == v0;
    
    
    bool v8;
    if (v5){
        
        
        double v6;
        v6 = log(v3);
        
        
        bool v7;
        v7 = v6 == v2;
        
        
        v8 = v7;
    } else {
        
        
        v8 = false;
    }
    
    
    bool v11;
    if (v8){
        
        
        float v9;
        v9 = expf(v0);
        
        
        bool v10;
        v10 = v9 == v1;
        
        
        v11 = v10;
    } else {
        
        
        v11 = false;
    }
    
    
    bool v14;
    if (v11){
        
        
        double v12;
        v12 = exp(v2);
        
        
        bool v13;
        v13 = v12 == v3;
        
        
        v14 = v13;
    } else {
        
        
        v14 = false;
    }
    
    
    bool v17;
    if (v14){
        
        
        float v15;
        v15 = tanhf(v0);
        
        
        bool v16;
        v16 = v15 == v0;
        
        
        v17 = v16;
    } else {
        
        
        v17 = false;
    }
    
    
    bool v20;
    if (v17){
        
        
        double v18;
        v18 = tanh(v2);
        
        
        bool v19;
        v19 = v18 == v2;
        
        
        v20 = v19;
    } else {
        
        
        v20 = false;
    }
    
    
    bool v23;
    if (v20){
        
        
        float v21;
        v21 = sinf(v0);
        
        
        bool v22;
        v22 = v21 == v0;
        
        
        v23 = v22;
    } else {
        
        
        v23 = false;
    }
    
    
    bool v26;
    if (v23){
        
        
        double v24;
        v24 = sin(v2);
        
        
        bool v25;
        v25 = v24 == v2;
        
        
        v26 = v25;
    } else {
        
        
        v26 = false;
    }
    
    
    bool v29;
    if (v26){
        
        
        float v27;
        v27 = cosf(v0);
        
        
        bool v28;
        v28 = v27 == v1;
        
        
        v29 = v28;
    } else {
        
        
        v29 = false;
    }
    
    
    bool v32;
    if (v29){
        
        
        double v30;
        v30 = cos(v2);
        
        
        bool v31;
        v31 = v30 == v3;
        
        
        v32 = v31;
    } else {
        
        
        v32 = false;
    }
    
    
    if (v32){
        
        
        return 0l;
    } else {
        
        
        return 1l;
    }
}
