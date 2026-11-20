#include "main.hpp"
int main() {
    float v0;
    v0 = nanf("");
    double v1;
    v1 = nan("");
    float v2;
    v2 = 1.0f;
    double v3;
    v3 = 1.0;
    bool v4;
    v4 = isnan(v0);
    bool v6;
    if (v4){
        bool v5;
        v5 = isnan(v1);
        v6 = v5;
    } else {
        v6 = false;
    }
    if (v6){
        bool v7;
        v7 = isnan(v2);
        bool v9;
        if (v7){
            v9 = true;
        } else {
            bool v8;
            v8 = isnan(v3);
            v9 = v8;
        }
        if (v9){
            return 2;
        } else {
            return 0;
        }
    } else {
        return 1;
    }
}
