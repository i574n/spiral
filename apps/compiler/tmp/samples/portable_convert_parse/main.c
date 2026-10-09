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
    
    
    String * v79;
    v79 = StringLit(5, "1011");
    
    
    int32_t v101;
    v101 = (int32_t)strtol((v79)->ptr, NULL, 2l);
    
    StringDecref(v79);
    
    printf("%d\n", v101);
    
    
    String * v104;
    v104 = StringLit(4, "-42");
    
    
    int32_t v150;
    v150 = (int32_t)strtol((v104)->ptr, NULL, 10l);
    
    StringDecref(v104);
    
    printf("%d\n", v150);
    
    
    String * v153;
    v153 = StringLit(6, " 123 ");
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    bool v765;
    v765 = spiral_integer_text_ok((v153)->ptr);
    
    
    int64_t v766;
    v766 = strtoll((v153)->ptr, NULL, 10);
    
    StringDecref(v153);
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
            
            
            
            String * v798;
            v798 = StringLit(5, "none");
            
            
            
            printf("%s\n", (v798)->ptr);
            
            StringDecref(v798);
            
            break;
        }
        case 0: { // Some
            int32_t v786 = v774.case0.v0;
            
            
            
            printf("%d\n", v786);
            
            
            
            break;
        }
    }
    
    USDecref0(&(v774));
    String * v799;
    v799 = StringLit(4, "12x");
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    bool v800;
    v800 = spiral_integer_text_ok((v799)->ptr);
    
    
    int64_t v801;
    v801 = strtoll((v799)->ptr, NULL, 10);
    
    StringDecref(v799);
    int32_t v802;
    v802 = (int32_t)v801;
    
    
    bool v806;
    if (v800){
        
        
        bool v803;
        v803 = v801 >= -2147483648ll;
        
        
        if (v803){
            
            
            bool v804;
            v804 = v801 <= 2147483647ll;
            
            
            v806 = v804;
        } else {
            
            
            v806 = false;
        }
    } else {
        
        
        v806 = false;
    }
    
    
    US0 v809;
    if (v806){
        
        
        v809 = US0_0(v802);
    } else {
        
        
        v809 = US0_1();
    }
    
    
    
    switch (v809.tag) {
        case 1: { // None
            
            
            
            String * v811;
            v811 = StringLit(5, "none");
            
            
            
            printf("%s\n", (v811)->ptr);
            
            StringDecref(v811);
            
            break;
        }
        case 0: { // Some
            int32_t v810 = v809.case0.v0;
            
            
            
            printf("%d\n", v810);
            
            
            
            break;
        }
    }
    
    USDecref0(&(v809));
    String * v812;
    v812 = StringLit(1, "");
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    bool v813;
    v813 = spiral_integer_text_ok((v812)->ptr);
    
    
    int64_t v814;
    v814 = strtoll((v812)->ptr, NULL, 10);
    
    StringDecref(v812);
    int32_t v815;
    v815 = (int32_t)v814;
    
    
    bool v819;
    if (v813){
        
        
        bool v816;
        v816 = v814 >= -2147483648ll;
        
        
        if (v816){
            
            
            bool v817;
            v817 = v814 <= 2147483647ll;
            
            
            v819 = v817;
        } else {
            
            
            v819 = false;
        }
    } else {
        
        
        v819 = false;
    }
    
    
    US0 v822;
    if (v819){
        
        
        v822 = US0_0(v815);
    } else {
        
        
        v822 = US0_1();
    }
    
    
    
    switch (v822.tag) {
        case 1: { // None
            
            
            
            String * v824;
            v824 = StringLit(5, "none");
            
            
            
            printf("%s\n", (v824)->ptr);
            
            StringDecref(v824);
            
            break;
        }
        case 0: { // Some
            int32_t v823 = v822.case0.v0;
            
            
            
            printf("%d\n", v823);
            
            
            
            break;
        }
    }
    
    USDecref0(&(v822));
    String * v825;
    v825 = StringLit(3, "+7");
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    bool v826;
    v826 = spiral_integer_text_ok((v825)->ptr);
    
    
    int64_t v827;
    v827 = strtoll((v825)->ptr, NULL, 10);
    
    StringDecref(v825);
    int32_t v828;
    v828 = (int32_t)v827;
    
    
    bool v832;
    if (v826){
        
        
        bool v829;
        v829 = v827 >= -2147483648ll;
        
        
        if (v829){
            
            
            bool v830;
            v830 = v827 <= 2147483647ll;
            
            
            v832 = v830;
        } else {
            
            
            v832 = false;
        }
    } else {
        
        
        v832 = false;
    }
    
    
    US0 v835;
    if (v832){
        
        
        v835 = US0_0(v828);
    } else {
        
        
        v835 = US0_1();
    }
    
    
    
    switch (v835.tag) {
        case 1: { // None
            
            
            
            String * v837;
            v837 = StringLit(5, "none");
            
            
            
            printf("%s\n", (v837)->ptr);
            
            StringDecref(v837);
            
            break;
        }
        case 0: { // Some
            int32_t v836 = v835.case0.v0;
            
            
            
            printf("%d\n", v836);
            
            
            
            break;
        }
    }
    
    USDecref0(&(v835));
    return 0l;
}
