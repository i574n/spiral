#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
int32_t main(){
    
    
    float v1;
    v1 = nanf("");
    
    
    double v6;
    v6 = nan("");
    
    
    float v10;
    v10 = 1.0f;
    
    
    double v11;
    v11 = 1.0;
    
    
    bool v12;
    v12 = isnan(v1);
    
    
    bool v14;
    if (v12){
        
        
        bool v13;
        v13 = isnan(v6);
        
        
        v14 = v13;
    } else {
        
        
        v14 = false;
    }
    
    
    if (v14){
        
        
        bool v15;
        v15 = isnan(v10);
        
        
        bool v17;
        if (v15){
            
            
            v17 = true;
        } else {
            
            
            bool v16;
            v16 = isnan(v11);
            
            
            v17 = v16;
        }
        
        
        if (v17){
            
            
            return 2l;
        } else {
            
            
            return 0l;
        }
    } else {
        
        
        return 1l;
    }
}
