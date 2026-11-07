#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
int32_t main(){
    double v0 = 7.5;
    double v1 = 2.0;
    double v2 = -7.5;
    double v3 = fmod(v0, v1);
    bool v4 = v3 == 1.5;
    bool v7;
    if (v4){
        double v5 = fmod(v2, v1);
        bool v6 = v5 == -1.5;
        v7 = v6;
    } else {
        v7 = false;
    }
    if (v7){
        return 15l;
    } else {
        return 1l;
    }
}
