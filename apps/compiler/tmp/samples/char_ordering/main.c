#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
int32_t main(){
    char v0 = 'a';
    char v1 = 'b';
    bool v2 = v0 < v1;
    if (v2){
        bool v3 = v1 > v0;
        if (v3){
            bool v4 = v0 <= v0;
            if (v4){
                return 0l;
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
