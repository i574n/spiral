#include "main.hpp"
int main() {
    float v5;
    v5 = nanf("");
    double v12;
    v12 = nan("");
    float v14;
    v14 = 1.0f;
    double v15;
    v15 = 1.0;
    bool v16;
    v16 = isnan(v5);
    bool v18;
    if (v16){
        bool v17;
        v17 = isnan(v12);
        v18 = v17;
    } else {
        v18 = false;
    }
    if (v18){
        bool v19;
        v19 = isnan(v14);
        bool v21;
        if (v19){
            v21 = true;
        } else {
            bool v20;
            v20 = isnan(v15);
            v21 = v20;
        }
        if (v21){
            return 2;
        } else {
            return 0;
        }
    } else {
        return 1;
    }
}
