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
    
    
    int32_t v58;
    v58 = (int32_t)strtol((v0)->ptr, NULL, 16l);
    
    StringDecref(v0);
    
    printf("%d\n", v58);
    
    
    String * v67;
    v67 = StringLit(5, "1011");
    
    
    int32_t v89;
    v89 = (int32_t)strtol((v67)->ptr, NULL, 2l);
    
    StringDecref(v67);
    
    printf("%d\n", v89);
    
    
    String * v91;
    v91 = StringLit(4, "-42");
    
    
    int32_t v136;
    v136 = (int32_t)strtol((v91)->ptr, NULL, 10l);
    
    StringDecref(v91);
    
    printf("%d\n", v136);
    
    
    String * v138;
    v138 = StringLit(6, " 123 ");
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    bool v680;
    v680 = spiral_integer_text_ok((v138)->ptr);
    
    
    int64_t v681;
    v681 = strtoll((v138)->ptr, NULL, 10);
    
    StringDecref(v138);
    int32_t v682;
    v682 = (int32_t)v681;
    
    
    bool v686;
    if (v680){
        
        
        bool v683;
        v683 = v681 >= -2147483648ll;
        
        
        if (v683){
            
            
            bool v684;
            v684 = v681 <= 2147483647ll;
            
            
            v686 = v684;
        } else {
            
            
            v686 = false;
        }
    } else {
        
        
        v686 = false;
    }
    
    
    US0 v689;
    if (v686){
        
        
        v689 = US0_0(v682);
    } else {
        
        
        v689 = US0_1();
    }
    
    
    
    switch (v689.tag) {
        case 1: { // None
            
            
            
            String * v712;
            v712 = StringLit(5, "none");
            
            
            
            printf("%s\n", (v712)->ptr);
            
            StringDecref(v712);
            
            break;
        }
        case 0: { // Some
            int32_t v700 = v689.case0.v0;
            
            
            
            printf("%d\n", v700);
            
            
            
            break;
        }
    }
    
    USDecref0(&(v689));
    String * v713;
    v713 = StringLit(4, "12x");
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    bool v714;
    v714 = spiral_integer_text_ok((v713)->ptr);
    
    
    int64_t v715;
    v715 = strtoll((v713)->ptr, NULL, 10);
    
    StringDecref(v713);
    int32_t v716;
    v716 = (int32_t)v715;
    
    
    bool v720;
    if (v714){
        
        
        bool v717;
        v717 = v715 >= -2147483648ll;
        
        
        if (v717){
            
            
            bool v718;
            v718 = v715 <= 2147483647ll;
            
            
            v720 = v718;
        } else {
            
            
            v720 = false;
        }
    } else {
        
        
        v720 = false;
    }
    
    
    US0 v723;
    if (v720){
        
        
        v723 = US0_0(v716);
    } else {
        
        
        v723 = US0_1();
    }
    
    
    
    switch (v723.tag) {
        case 1: { // None
            
            
            
            String * v725;
            v725 = StringLit(5, "none");
            
            
            
            printf("%s\n", (v725)->ptr);
            
            StringDecref(v725);
            
            break;
        }
        case 0: { // Some
            int32_t v724 = v723.case0.v0;
            
            
            
            printf("%d\n", v724);
            
            
            
            break;
        }
    }
    
    USDecref0(&(v723));
    String * v726;
    v726 = StringLit(1, "");
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    bool v727;
    v727 = spiral_integer_text_ok((v726)->ptr);
    
    
    int64_t v728;
    v728 = strtoll((v726)->ptr, NULL, 10);
    
    StringDecref(v726);
    int32_t v729;
    v729 = (int32_t)v728;
    
    
    bool v733;
    if (v727){
        
        
        bool v730;
        v730 = v728 >= -2147483648ll;
        
        
        if (v730){
            
            
            bool v731;
            v731 = v728 <= 2147483647ll;
            
            
            v733 = v731;
        } else {
            
            
            v733 = false;
        }
    } else {
        
        
        v733 = false;
    }
    
    
    US0 v736;
    if (v733){
        
        
        v736 = US0_0(v729);
    } else {
        
        
        v736 = US0_1();
    }
    
    
    
    switch (v736.tag) {
        case 1: { // None
            
            
            
            String * v738;
            v738 = StringLit(5, "none");
            
            
            
            printf("%s\n", (v738)->ptr);
            
            StringDecref(v738);
            
            break;
        }
        case 0: { // Some
            int32_t v737 = v736.case0.v0;
            
            
            
            printf("%d\n", v737);
            
            
            
            break;
        }
    }
    
    USDecref0(&(v736));
    String * v739;
    v739 = StringLit(3, "+7");
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    bool v740;
    v740 = spiral_integer_text_ok((v739)->ptr);
    
    
    int64_t v741;
    v741 = strtoll((v739)->ptr, NULL, 10);
    
    StringDecref(v739);
    int32_t v742;
    v742 = (int32_t)v741;
    
    
    bool v746;
    if (v740){
        
        
        bool v743;
        v743 = v741 >= -2147483648ll;
        
        
        if (v743){
            
            
            bool v744;
            v744 = v741 <= 2147483647ll;
            
            
            v746 = v744;
        } else {
            
            
            v746 = false;
        }
    } else {
        
        
        v746 = false;
    }
    
    
    US0 v749;
    if (v746){
        
        
        v749 = US0_0(v742);
    } else {
        
        
        v749 = US0_1();
    }
    
    
    
    switch (v749.tag) {
        case 1: { // None
            
            
            
            String * v751;
            v751 = StringLit(5, "none");
            
            
            
            printf("%s\n", (v751)->ptr);
            
            StringDecref(v751);
            
            break;
        }
        case 0: { // Some
            int32_t v750 = v749.case0.v0;
            
            
            
            printf("%d\n", v750);
            
            
            
            break;
        }
    }
    
    USDecref0(&(v749));
    return 0l;
}
