#include <stdint.h>
#include <stdio.h>
#include <string.h>
#include <stdbool.h>
#include <stdlib.h>
#include <ctype.h>
#include <errno.h>
static bool spiral_integer_text_ok(const char *s) { char *end; while (isspace((unsigned char)*s)) s++; if (!*s) return false; errno = 0; strtoll(s, &end, 10); if (errno != 0 || end == s) return false; while (isspace((unsigned char)*end)) end++; return *end == 0; }
typedef struct {
    int refc;
    uint32_t len;
    char ptr[];
} Array0;
typedef Array0 String;
typedef struct {
    int tag;
    union {
        struct {
            int32_t v0;
        } case0; // Some
    };
} US0;
static inline void ArrayDecrefBody0(Array0 * x){
    (void)x;
}
void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(char) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array0 * ArrayLit0(uint32_t len, char * ptr){
    Array0 * x = ArrayCreate0(len, false);
    memcpy(x->ptr, ptr, sizeof(char) * len);
    return x;
}
static inline void StringDecref(String * x){
    return ArrayDecref0(x);
}
static inline String * StringLit(uint32_t len, char * ptr){
    return ArrayLit0(len, ptr);
}
static inline void USIncrefBody0(US0 * x){
    switch (x->tag) {
    }
}
static inline void USDecrefBody0(US0 * x){
    switch (x->tag) {
    }
}
void USIncref0(US0 * x){ USIncrefBody0(x); }
void USDecref0(US0 * x){ USDecrefBody0(x); }
US0 US0_0(int32_t v0) { // Some
    US0 x;
    x.tag = 0;
    x.case0.v0 = v0;
    return x;
}
US0 US0_1() { // None
    US0 x;
    x.tag = 1;
    return x;
}
int32_t main(){
    
    
    String * v0;
    v0 = StringLit(3, "ff");
    
    
    int32_t v59;
    v59 = (int32_t)strtol((v0)->ptr, NULL, 16l);
    
    StringDecref(v0);
    
    printf("%d\n", v59);
    
    
    String * v69;
    v69 = StringLit(5, "1011");
    
    
    int32_t v91;
    v91 = (int32_t)strtol((v69)->ptr, NULL, 2l);
    
    StringDecref(v69);
    
    printf("%d\n", v91);
    
    
    String * v94;
    v94 = StringLit(4, "-42");
    
    
    int32_t v140;
    v140 = (int32_t)strtol((v94)->ptr, NULL, 10l);
    
    StringDecref(v94);
    
    printf("%d\n", v140);
    
    
    String * v143;
    v143 = StringLit(6, " 123 ");
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    bool v765;
    v765 = spiral_integer_text_ok((v143)->ptr);
    
    
    int64_t v766;
    v766 = strtoll((v143)->ptr, NULL, 10);
    
    StringDecref(v143);
    int32_t v767;
    v767 = (int32_t)v766;
    
    
    bool v771;
    if (v765){
        
        
        bool v768;
        v768 = v766 >= -2147483648ll;
        
        
        if (v768){
            
            
            bool v769;
            v769 = v766 <= 2147483647ll;
            
            
            v771 = v769;
        } else {
            
            
            v771 = false;
        }
    } else {
        
        
        v771 = false;
    }
    
    
    US0 v774;
    if (v771){
        
        
        v774 = US0_0(v767);
    } else {
        
        
        v774 = US0_1();
    }
    
    
    
    switch (v774.tag) {
        case 1: { // None
            
            
            
            String * v807;
            v807 = StringLit(5, "none");
            
            
            
            printf("%s\n", (v807)->ptr);
            
            StringDecref(v807);
            
            break;
        }
        case 0: { // Some
            int32_t v795 = v774.case0.v0;
            
            
            
            printf("%d\n", v795);
            
            
            
            break;
        }
    }
    
    USDecref0(&(v774));
    String * v808;
    v808 = StringLit(4, "12x");
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    bool v809;
    v809 = spiral_integer_text_ok((v808)->ptr);
    
    
    int64_t v810;
    v810 = strtoll((v808)->ptr, NULL, 10);
    
    StringDecref(v808);
    int32_t v811;
    v811 = (int32_t)v810;
    
    
    bool v815;
    if (v809){
        
        
        bool v812;
        v812 = v810 >= -2147483648ll;
        
        
        if (v812){
            
            
            bool v813;
            v813 = v810 <= 2147483647ll;
            
            
            v815 = v813;
        } else {
            
            
            v815 = false;
        }
    } else {
        
        
        v815 = false;
    }
    
    
    US0 v818;
    if (v815){
        
        
        v818 = US0_0(v811);
    } else {
        
        
        v818 = US0_1();
    }
    
    
    
    switch (v818.tag) {
        case 1: { // None
            
            
            
            String * v820;
            v820 = StringLit(5, "none");
            
            
            
            printf("%s\n", (v820)->ptr);
            
            StringDecref(v820);
            
            break;
        }
        case 0: { // Some
            int32_t v819 = v818.case0.v0;
            
            
            
            printf("%d\n", v819);
            
            
            
            break;
        }
    }
    
    USDecref0(&(v818));
    String * v821;
    v821 = StringLit(1, "");
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    bool v822;
    v822 = spiral_integer_text_ok((v821)->ptr);
    
    
    int64_t v823;
    v823 = strtoll((v821)->ptr, NULL, 10);
    
    StringDecref(v821);
    int32_t v824;
    v824 = (int32_t)v823;
    
    
    bool v828;
    if (v822){
        
        
        bool v825;
        v825 = v823 >= -2147483648ll;
        
        
        if (v825){
            
            
            bool v826;
            v826 = v823 <= 2147483647ll;
            
            
            v828 = v826;
        } else {
            
            
            v828 = false;
        }
    } else {
        
        
        v828 = false;
    }
    
    
    US0 v831;
    if (v828){
        
        
        v831 = US0_0(v824);
    } else {
        
        
        v831 = US0_1();
    }
    
    
    
    switch (v831.tag) {
        case 1: { // None
            
            
            
            String * v833;
            v833 = StringLit(5, "none");
            
            
            
            printf("%s\n", (v833)->ptr);
            
            StringDecref(v833);
            
            break;
        }
        case 0: { // Some
            int32_t v832 = v831.case0.v0;
            
            
            
            printf("%d\n", v832);
            
            
            
            break;
        }
    }
    
    USDecref0(&(v831));
    String * v834;
    v834 = StringLit(3, "+7");
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    bool v835;
    v835 = spiral_integer_text_ok((v834)->ptr);
    
    
    int64_t v836;
    v836 = strtoll((v834)->ptr, NULL, 10);
    
    StringDecref(v834);
    int32_t v837;
    v837 = (int32_t)v836;
    
    
    bool v841;
    if (v835){
        
        
        bool v838;
        v838 = v836 >= -2147483648ll;
        
        
        if (v838){
            
            
            bool v839;
            v839 = v836 <= 2147483647ll;
            
            
            v841 = v839;
        } else {
            
            
            v841 = false;
        }
    } else {
        
        
        v841 = false;
    }
    
    
    US0 v844;
    if (v841){
        
        
        v844 = US0_0(v837);
    } else {
        
        
        v844 = US0_1();
    }
    
    
    
    switch (v844.tag) {
        case 1: { // None
            
            
            
            String * v846;
            v846 = StringLit(5, "none");
            
            
            
            printf("%s\n", (v846)->ptr);
            
            StringDecref(v846);
            
            break;
        }
        case 0: { // Some
            int32_t v845 = v844.case0.v0;
            
            
            
            printf("%d\n", v845);
            
            
            
            break;
        }
    }
    
    USDecref0(&(v844));
    return 0l;
}
