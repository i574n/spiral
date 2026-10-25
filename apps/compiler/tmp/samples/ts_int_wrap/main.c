#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
int32_t main(){
    
    
    uint8_t v0;
    v0 = 250u;
    
    
    uint8_t v1;
    v1 = 10u;
    
    
    uint32_t v2;
    v2 = 4294967295ul;
    
    
    uint64_t v3;
    v3 = 18446744073709551615ull;
    
    
    int8_t v4;
    v4 = 127;
    
    
    int8_t v5;
    v5 = 1;
    
    
    int32_t v6;
    v6 = 7l;
    
    
    int32_t v7;
    v7 = 2l;
    
    
    int64_t v8;
    v8 = 9223372036854775807ll;
    
    
    int32_t v9;
    v9 = -v6;
    
    
    int64_t v10;
    v10 = -v8;
    
    
    uint8_t v11;
    v11 = v0 + v1;
    
    
    bool v12;
    v12 = v11 == 4u;
    
    
    if (v12){
        
        
        uint32_t v13;
        v13 = v2 + 1ul;
        
        
        bool v14;
        v14 = v13 == 0ul;
        
        
        if (v14){
            
            
            uint32_t v15;
            v15 = v2 * v2;
            
            
            bool v16;
            v16 = v15 == 1ul;
            
            
            if (v16){
                
                
                uint64_t v17;
                v17 = v3 + 1ull;
                
                
                bool v18;
                v18 = v17 == 0ull;
                
                
                if (v18){
                    
                    
                    uint64_t v19;
                    v19 = v3 * v3;
                    
                    
                    bool v20;
                    v20 = v19 == 1ull;
                    
                    
                    if (v20){
                        
                        
                        uint64_t v21;
                        v21 = v3 / 3ull;
                        
                        
                        bool v22;
                        v22 = v21 == 6148914691236517205ull;
                        
                        
                        if (v22){
                            
                            
                            int8_t v23;
                            v23 = v4 + v5;
                            
                            
                            bool v24;
                            v24 = v23 < 0;
                            
                            
                            if (v24){
                                
                                
                                int32_t v25;
                                v25 = v9 / v7;
                                
                                
                                bool v26;
                                v26 = v25 == -3l;
                                
                                
                                if (v26){
                                    
                                    
                                    int32_t v27;
                                    v27 = v9 % v7;
                                    
                                    
                                    bool v28;
                                    v28 = v27 == -1l;
                                    
                                    
                                    if (v28){
                                        
                                        
                                        int64_t v29;
                                        v29 = v10 % 10ll;
                                        
                                        
                                        bool v30;
                                        v30 = v29 == -7ll;
                                        
                                        
                                        if (v30){
                                            
                                            
                                            uint32_t v31;
                                            v31 = v2 >> 28l;
                                            
                                            
                                            bool v32;
                                            v32 = v31 == 15ul;
                                            
                                            
                                            if (v32){
                                                
                                                
                                                int32_t v33;
                                                v33 = v9 >> 1l;
                                                
                                                
                                                bool v34;
                                                v34 = v33 == -4l;
                                                
                                                
                                                if (v34){
                                                    
                                                    
                                                    return 0l;
                                                } else {
                                                    
                                                    
                                                    return 12l;
                                                }
                                            } else {
                                                
                                                
                                                return 11l;
                                            }
                                        } else {
                                            
                                            
                                            return 10l;
                                        }
                                    } else {
                                        
                                        
                                        return 9l;
                                    }
                                } else {
                                    
                                    
                                    return 8l;
                                }
                            } else {
                                
                                
                                return 7l;
                            }
                        } else {
                            
                            
                            return 6l;
                        }
                    } else {
                        
                        
                        return 5l;
                    }
                } else {
                    
                    
                    return 4l;
                }
            } else {
                
                
                return 3l;
            }
        } else {
            
            
            return 2l;
        }
    } else {
        
        
        return 1l;
    }
}
