#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct Fun0 Fun0;
typedef struct UH0 UH0;
void UHDecref0(UH0 * x);
struct UH0 {
    int refc;
    int tag;
    union {
        struct {
            uint64_t v0;
            Fun0 * v1;
        } case0; // Cons
    };
};
struct Fun0{
    int refc;
    void (*decref_fptr)(Fun0 *);
    UH0 * (*fptr)(Fun0 *);
};
typedef struct Closure79 Closure79;
struct Closure79 {
    int refc;
    void (*decref_fptr)(Closure79 *);
    UH0 * (*fptr)(Closure79 *);
};
typedef struct Closure78 Closure78;
struct Closure78 {
    int refc;
    void (*decref_fptr)(Closure78 *);
    UH0 * (*fptr)(Closure78 *);
};
typedef struct Closure77 Closure77;
struct Closure77 {
    int refc;
    void (*decref_fptr)(Closure77 *);
    UH0 * (*fptr)(Closure77 *);
};
typedef struct Closure76 Closure76;
struct Closure76 {
    int refc;
    void (*decref_fptr)(Closure76 *);
    UH0 * (*fptr)(Closure76 *);
};
typedef struct Closure75 Closure75;
struct Closure75 {
    int refc;
    void (*decref_fptr)(Closure75 *);
    UH0 * (*fptr)(Closure75 *);
};
typedef struct Closure74 Closure74;
struct Closure74 {
    int refc;
    void (*decref_fptr)(Closure74 *);
    UH0 * (*fptr)(Closure74 *);
};
typedef struct Closure73 Closure73;
struct Closure73 {
    int refc;
    void (*decref_fptr)(Closure73 *);
    UH0 * (*fptr)(Closure73 *);
};
typedef struct Closure72 Closure72;
struct Closure72 {
    int refc;
    void (*decref_fptr)(Closure72 *);
    UH0 * (*fptr)(Closure72 *);
};
typedef struct Closure71 Closure71;
struct Closure71 {
    int refc;
    void (*decref_fptr)(Closure71 *);
    UH0 * (*fptr)(Closure71 *);
};
typedef struct Closure70 Closure70;
struct Closure70 {
    int refc;
    void (*decref_fptr)(Closure70 *);
    UH0 * (*fptr)(Closure70 *);
};
typedef struct Closure69 Closure69;
struct Closure69 {
    int refc;
    void (*decref_fptr)(Closure69 *);
    UH0 * (*fptr)(Closure69 *);
};
typedef struct Closure68 Closure68;
struct Closure68 {
    int refc;
    void (*decref_fptr)(Closure68 *);
    UH0 * (*fptr)(Closure68 *);
};
typedef struct Closure67 Closure67;
struct Closure67 {
    int refc;
    void (*decref_fptr)(Closure67 *);
    UH0 * (*fptr)(Closure67 *);
};
typedef struct Closure66 Closure66;
struct Closure66 {
    int refc;
    void (*decref_fptr)(Closure66 *);
    UH0 * (*fptr)(Closure66 *);
};
typedef struct Closure65 Closure65;
struct Closure65 {
    int refc;
    void (*decref_fptr)(Closure65 *);
    UH0 * (*fptr)(Closure65 *);
};
typedef struct Closure64 Closure64;
struct Closure64 {
    int refc;
    void (*decref_fptr)(Closure64 *);
    UH0 * (*fptr)(Closure64 *);
};
typedef struct Closure63 Closure63;
struct Closure63 {
    int refc;
    void (*decref_fptr)(Closure63 *);
    UH0 * (*fptr)(Closure63 *);
};
typedef struct Closure62 Closure62;
struct Closure62 {
    int refc;
    void (*decref_fptr)(Closure62 *);
    UH0 * (*fptr)(Closure62 *);
};
typedef struct Closure61 Closure61;
struct Closure61 {
    int refc;
    void (*decref_fptr)(Closure61 *);
    UH0 * (*fptr)(Closure61 *);
};
typedef struct Closure60 Closure60;
struct Closure60 {
    int refc;
    void (*decref_fptr)(Closure60 *);
    UH0 * (*fptr)(Closure60 *);
};
typedef struct Closure59 Closure59;
struct Closure59 {
    int refc;
    void (*decref_fptr)(Closure59 *);
    UH0 * (*fptr)(Closure59 *);
};
typedef struct Closure58 Closure58;
struct Closure58 {
    int refc;
    void (*decref_fptr)(Closure58 *);
    UH0 * (*fptr)(Closure58 *);
};
typedef struct Closure57 Closure57;
struct Closure57 {
    int refc;
    void (*decref_fptr)(Closure57 *);
    UH0 * (*fptr)(Closure57 *);
};
typedef struct Closure56 Closure56;
struct Closure56 {
    int refc;
    void (*decref_fptr)(Closure56 *);
    UH0 * (*fptr)(Closure56 *);
};
typedef struct Closure55 Closure55;
struct Closure55 {
    int refc;
    void (*decref_fptr)(Closure55 *);
    UH0 * (*fptr)(Closure55 *);
};
typedef struct Closure54 Closure54;
struct Closure54 {
    int refc;
    void (*decref_fptr)(Closure54 *);
    UH0 * (*fptr)(Closure54 *);
};
typedef struct Closure53 Closure53;
struct Closure53 {
    int refc;
    void (*decref_fptr)(Closure53 *);
    UH0 * (*fptr)(Closure53 *);
};
typedef struct Closure52 Closure52;
struct Closure52 {
    int refc;
    void (*decref_fptr)(Closure52 *);
    UH0 * (*fptr)(Closure52 *);
};
typedef struct Closure51 Closure51;
struct Closure51 {
    int refc;
    void (*decref_fptr)(Closure51 *);
    UH0 * (*fptr)(Closure51 *);
};
typedef struct Closure50 Closure50;
struct Closure50 {
    int refc;
    void (*decref_fptr)(Closure50 *);
    UH0 * (*fptr)(Closure50 *);
};
typedef struct Closure49 Closure49;
struct Closure49 {
    int refc;
    void (*decref_fptr)(Closure49 *);
    UH0 * (*fptr)(Closure49 *);
};
typedef struct Closure48 Closure48;
struct Closure48 {
    int refc;
    void (*decref_fptr)(Closure48 *);
    UH0 * (*fptr)(Closure48 *);
};
typedef struct Closure47 Closure47;
struct Closure47 {
    int refc;
    void (*decref_fptr)(Closure47 *);
    UH0 * (*fptr)(Closure47 *);
};
typedef struct Closure46 Closure46;
struct Closure46 {
    int refc;
    void (*decref_fptr)(Closure46 *);
    UH0 * (*fptr)(Closure46 *);
};
typedef struct Closure45 Closure45;
struct Closure45 {
    int refc;
    void (*decref_fptr)(Closure45 *);
    UH0 * (*fptr)(Closure45 *);
};
typedef struct Closure44 Closure44;
struct Closure44 {
    int refc;
    void (*decref_fptr)(Closure44 *);
    UH0 * (*fptr)(Closure44 *);
};
typedef struct Closure43 Closure43;
struct Closure43 {
    int refc;
    void (*decref_fptr)(Closure43 *);
    UH0 * (*fptr)(Closure43 *);
};
typedef struct Closure42 Closure42;
struct Closure42 {
    int refc;
    void (*decref_fptr)(Closure42 *);
    UH0 * (*fptr)(Closure42 *);
};
typedef struct Closure41 Closure41;
struct Closure41 {
    int refc;
    void (*decref_fptr)(Closure41 *);
    UH0 * (*fptr)(Closure41 *);
};
typedef struct Closure40 Closure40;
struct Closure40 {
    int refc;
    void (*decref_fptr)(Closure40 *);
    UH0 * (*fptr)(Closure40 *);
};
typedef struct Closure39 Closure39;
struct Closure39 {
    int refc;
    void (*decref_fptr)(Closure39 *);
    UH0 * (*fptr)(Closure39 *);
};
typedef struct Closure38 Closure38;
struct Closure38 {
    int refc;
    void (*decref_fptr)(Closure38 *);
    UH0 * (*fptr)(Closure38 *);
};
typedef struct Closure37 Closure37;
struct Closure37 {
    int refc;
    void (*decref_fptr)(Closure37 *);
    UH0 * (*fptr)(Closure37 *);
};
typedef struct Closure36 Closure36;
struct Closure36 {
    int refc;
    void (*decref_fptr)(Closure36 *);
    UH0 * (*fptr)(Closure36 *);
};
typedef struct Closure35 Closure35;
struct Closure35 {
    int refc;
    void (*decref_fptr)(Closure35 *);
    UH0 * (*fptr)(Closure35 *);
};
typedef struct Closure34 Closure34;
struct Closure34 {
    int refc;
    void (*decref_fptr)(Closure34 *);
    UH0 * (*fptr)(Closure34 *);
};
typedef struct Closure33 Closure33;
struct Closure33 {
    int refc;
    void (*decref_fptr)(Closure33 *);
    UH0 * (*fptr)(Closure33 *);
};
typedef struct Closure32 Closure32;
struct Closure32 {
    int refc;
    void (*decref_fptr)(Closure32 *);
    UH0 * (*fptr)(Closure32 *);
};
typedef struct Closure31 Closure31;
struct Closure31 {
    int refc;
    void (*decref_fptr)(Closure31 *);
    UH0 * (*fptr)(Closure31 *);
};
typedef struct Closure30 Closure30;
struct Closure30 {
    int refc;
    void (*decref_fptr)(Closure30 *);
    UH0 * (*fptr)(Closure30 *);
};
typedef struct Closure29 Closure29;
struct Closure29 {
    int refc;
    void (*decref_fptr)(Closure29 *);
    UH0 * (*fptr)(Closure29 *);
};
typedef struct Closure28 Closure28;
struct Closure28 {
    int refc;
    void (*decref_fptr)(Closure28 *);
    UH0 * (*fptr)(Closure28 *);
};
typedef struct Closure27 Closure27;
struct Closure27 {
    int refc;
    void (*decref_fptr)(Closure27 *);
    UH0 * (*fptr)(Closure27 *);
};
typedef struct Closure26 Closure26;
struct Closure26 {
    int refc;
    void (*decref_fptr)(Closure26 *);
    UH0 * (*fptr)(Closure26 *);
};
typedef struct Closure25 Closure25;
struct Closure25 {
    int refc;
    void (*decref_fptr)(Closure25 *);
    UH0 * (*fptr)(Closure25 *);
};
typedef struct Closure24 Closure24;
struct Closure24 {
    int refc;
    void (*decref_fptr)(Closure24 *);
    UH0 * (*fptr)(Closure24 *);
};
typedef struct Closure23 Closure23;
struct Closure23 {
    int refc;
    void (*decref_fptr)(Closure23 *);
    UH0 * (*fptr)(Closure23 *);
};
typedef struct Closure22 Closure22;
struct Closure22 {
    int refc;
    void (*decref_fptr)(Closure22 *);
    UH0 * (*fptr)(Closure22 *);
};
typedef struct Closure21 Closure21;
struct Closure21 {
    int refc;
    void (*decref_fptr)(Closure21 *);
    UH0 * (*fptr)(Closure21 *);
};
typedef struct Closure20 Closure20;
struct Closure20 {
    int refc;
    void (*decref_fptr)(Closure20 *);
    UH0 * (*fptr)(Closure20 *);
};
typedef struct Closure19 Closure19;
struct Closure19 {
    int refc;
    void (*decref_fptr)(Closure19 *);
    UH0 * (*fptr)(Closure19 *);
};
typedef struct Closure18 Closure18;
struct Closure18 {
    int refc;
    void (*decref_fptr)(Closure18 *);
    UH0 * (*fptr)(Closure18 *);
};
typedef struct Closure17 Closure17;
struct Closure17 {
    int refc;
    void (*decref_fptr)(Closure17 *);
    UH0 * (*fptr)(Closure17 *);
};
typedef struct Closure16 Closure16;
struct Closure16 {
    int refc;
    void (*decref_fptr)(Closure16 *);
    UH0 * (*fptr)(Closure16 *);
};
typedef struct Closure15 Closure15;
struct Closure15 {
    int refc;
    void (*decref_fptr)(Closure15 *);
    UH0 * (*fptr)(Closure15 *);
};
typedef struct Closure14 Closure14;
struct Closure14 {
    int refc;
    void (*decref_fptr)(Closure14 *);
    UH0 * (*fptr)(Closure14 *);
};
typedef struct Closure13 Closure13;
struct Closure13 {
    int refc;
    void (*decref_fptr)(Closure13 *);
    UH0 * (*fptr)(Closure13 *);
};
typedef struct Closure12 Closure12;
struct Closure12 {
    int refc;
    void (*decref_fptr)(Closure12 *);
    UH0 * (*fptr)(Closure12 *);
};
typedef struct Closure11 Closure11;
struct Closure11 {
    int refc;
    void (*decref_fptr)(Closure11 *);
    UH0 * (*fptr)(Closure11 *);
};
typedef struct Closure10 Closure10;
struct Closure10 {
    int refc;
    void (*decref_fptr)(Closure10 *);
    UH0 * (*fptr)(Closure10 *);
};
typedef struct Closure9 Closure9;
struct Closure9 {
    int refc;
    void (*decref_fptr)(Closure9 *);
    UH0 * (*fptr)(Closure9 *);
};
typedef struct Closure8 Closure8;
struct Closure8 {
    int refc;
    void (*decref_fptr)(Closure8 *);
    UH0 * (*fptr)(Closure8 *);
};
typedef struct Closure7 Closure7;
struct Closure7 {
    int refc;
    void (*decref_fptr)(Closure7 *);
    UH0 * (*fptr)(Closure7 *);
};
typedef struct Closure6 Closure6;
struct Closure6 {
    int refc;
    void (*decref_fptr)(Closure6 *);
    UH0 * (*fptr)(Closure6 *);
};
typedef struct Closure5 Closure5;
struct Closure5 {
    int refc;
    void (*decref_fptr)(Closure5 *);
    UH0 * (*fptr)(Closure5 *);
};
typedef struct Closure4 Closure4;
struct Closure4 {
    int refc;
    void (*decref_fptr)(Closure4 *);
    UH0 * (*fptr)(Closure4 *);
};
typedef struct Closure3 Closure3;
struct Closure3 {
    int refc;
    void (*decref_fptr)(Closure3 *);
    UH0 * (*fptr)(Closure3 *);
};
typedef struct Closure2 Closure2;
struct Closure2 {
    int refc;
    void (*decref_fptr)(Closure2 *);
    UH0 * (*fptr)(Closure2 *);
};
typedef struct Closure1 Closure1;
struct Closure1 {
    int refc;
    void (*decref_fptr)(Closure1 *);
    UH0 * (*fptr)(Closure1 *);
};
typedef struct Closure0 Closure0;
struct Closure0 {
    int refc;
    void (*decref_fptr)(Closure0 *);
    UH0 * (*fptr)(Closure0 *);
};
static inline void UHDecrefBody0(UH0 * x){
    switch (x->tag) {
        case 0: {
            x->case0.v1->decref_fptr(x->case0.v1);
            break;
        }
    }
}
void UHDecref0(UH0 * x){
    if (x != NULL && --(x->refc) == 0) { UHDecrefBody0(x); free(x); }
}
UH0 * UH0_Cons(uint64_t v0, Fun0 * v1) { // Cons
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 0;
    x->refc = 1;
    x->case0.v0 = v0; x->case0.v1 = v1;
    return x;
}
UH0 * UH0_Nil() { // Nil
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 1;
    x->refc = 1;
    return x;
}
static inline void ClosureDecrefBody79(Closure79 * x){
    (void)x;
}
void ClosureDecref79(Closure79 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody79(x); free(x); }
}
UH0 * ClosureMethod79(Closure79 * x){
    
    
    ClosureDecref79(x);
    
    
    return UH0_Nil();
}
Fun0 * ClosureCreate79(){
    Closure79 * x = malloc(sizeof(Closure79));
    x->refc = 1;
    x->decref_fptr = ClosureDecref79;
    x->fptr = ClosureMethod79;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody78(Closure78 * x){
    (void)x;
}
void ClosureDecref78(Closure78 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody78(x); free(x); }
}
UH0 * ClosureMethod78(Closure78 * x){
    
    
    ClosureDecref78(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate79();
    
    
    return UH0_Cons(1ull, v0);
}
Fun0 * ClosureCreate78(){
    Closure78 * x = malloc(sizeof(Closure78));
    x->refc = 1;
    x->decref_fptr = ClosureDecref78;
    x->fptr = ClosureMethod78;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody77(Closure77 * x){
    (void)x;
}
void ClosureDecref77(Closure77 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody77(x); free(x); }
}
UH0 * ClosureMethod77(Closure77 * x){
    
    
    ClosureDecref77(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate78();
    
    
    return UH0_Cons(2ull, v0);
}
Fun0 * ClosureCreate77(){
    Closure77 * x = malloc(sizeof(Closure77));
    x->refc = 1;
    x->decref_fptr = ClosureDecref77;
    x->fptr = ClosureMethod77;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody76(Closure76 * x){
    (void)x;
}
void ClosureDecref76(Closure76 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody76(x); free(x); }
}
UH0 * ClosureMethod76(Closure76 * x){
    
    
    ClosureDecref76(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate77();
    
    
    return UH0_Cons(3ull, v0);
}
Fun0 * ClosureCreate76(){
    Closure76 * x = malloc(sizeof(Closure76));
    x->refc = 1;
    x->decref_fptr = ClosureDecref76;
    x->fptr = ClosureMethod76;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody75(Closure75 * x){
    (void)x;
}
void ClosureDecref75(Closure75 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody75(x); free(x); }
}
UH0 * ClosureMethod75(Closure75 * x){
    
    
    ClosureDecref75(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate76();
    
    
    return UH0_Cons(4ull, v0);
}
Fun0 * ClosureCreate75(){
    Closure75 * x = malloc(sizeof(Closure75));
    x->refc = 1;
    x->decref_fptr = ClosureDecref75;
    x->fptr = ClosureMethod75;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody74(Closure74 * x){
    (void)x;
}
void ClosureDecref74(Closure74 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody74(x); free(x); }
}
UH0 * ClosureMethod74(Closure74 * x){
    
    
    ClosureDecref74(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate75();
    
    
    return UH0_Cons(5ull, v0);
}
Fun0 * ClosureCreate74(){
    Closure74 * x = malloc(sizeof(Closure74));
    x->refc = 1;
    x->decref_fptr = ClosureDecref74;
    x->fptr = ClosureMethod74;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody73(Closure73 * x){
    (void)x;
}
void ClosureDecref73(Closure73 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody73(x); free(x); }
}
UH0 * ClosureMethod73(Closure73 * x){
    
    
    ClosureDecref73(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate74();
    
    
    return UH0_Cons(6ull, v0);
}
Fun0 * ClosureCreate73(){
    Closure73 * x = malloc(sizeof(Closure73));
    x->refc = 1;
    x->decref_fptr = ClosureDecref73;
    x->fptr = ClosureMethod73;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody72(Closure72 * x){
    (void)x;
}
void ClosureDecref72(Closure72 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody72(x); free(x); }
}
UH0 * ClosureMethod72(Closure72 * x){
    
    
    ClosureDecref72(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate73();
    
    
    return UH0_Cons(7ull, v0);
}
Fun0 * ClosureCreate72(){
    Closure72 * x = malloc(sizeof(Closure72));
    x->refc = 1;
    x->decref_fptr = ClosureDecref72;
    x->fptr = ClosureMethod72;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody71(Closure71 * x){
    (void)x;
}
void ClosureDecref71(Closure71 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody71(x); free(x); }
}
UH0 * ClosureMethod71(Closure71 * x){
    
    
    ClosureDecref71(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate72();
    
    
    return UH0_Cons(8ull, v0);
}
Fun0 * ClosureCreate71(){
    Closure71 * x = malloc(sizeof(Closure71));
    x->refc = 1;
    x->decref_fptr = ClosureDecref71;
    x->fptr = ClosureMethod71;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody70(Closure70 * x){
    (void)x;
}
void ClosureDecref70(Closure70 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody70(x); free(x); }
}
UH0 * ClosureMethod70(Closure70 * x){
    
    
    ClosureDecref70(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate71();
    
    
    return UH0_Cons(9ull, v0);
}
Fun0 * ClosureCreate70(){
    Closure70 * x = malloc(sizeof(Closure70));
    x->refc = 1;
    x->decref_fptr = ClosureDecref70;
    x->fptr = ClosureMethod70;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody69(Closure69 * x){
    (void)x;
}
void ClosureDecref69(Closure69 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody69(x); free(x); }
}
UH0 * ClosureMethod69(Closure69 * x){
    
    
    ClosureDecref69(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate70();
    
    
    return UH0_Cons(10ull, v0);
}
Fun0 * ClosureCreate69(){
    Closure69 * x = malloc(sizeof(Closure69));
    x->refc = 1;
    x->decref_fptr = ClosureDecref69;
    x->fptr = ClosureMethod69;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody68(Closure68 * x){
    (void)x;
}
void ClosureDecref68(Closure68 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody68(x); free(x); }
}
UH0 * ClosureMethod68(Closure68 * x){
    
    
    ClosureDecref68(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate69();
    
    
    return UH0_Cons(11ull, v0);
}
Fun0 * ClosureCreate68(){
    Closure68 * x = malloc(sizeof(Closure68));
    x->refc = 1;
    x->decref_fptr = ClosureDecref68;
    x->fptr = ClosureMethod68;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody67(Closure67 * x){
    (void)x;
}
void ClosureDecref67(Closure67 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody67(x); free(x); }
}
UH0 * ClosureMethod67(Closure67 * x){
    
    
    ClosureDecref67(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate68();
    
    
    return UH0_Cons(12ull, v0);
}
Fun0 * ClosureCreate67(){
    Closure67 * x = malloc(sizeof(Closure67));
    x->refc = 1;
    x->decref_fptr = ClosureDecref67;
    x->fptr = ClosureMethod67;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody66(Closure66 * x){
    (void)x;
}
void ClosureDecref66(Closure66 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody66(x); free(x); }
}
UH0 * ClosureMethod66(Closure66 * x){
    
    
    ClosureDecref66(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate67();
    
    
    return UH0_Cons(13ull, v0);
}
Fun0 * ClosureCreate66(){
    Closure66 * x = malloc(sizeof(Closure66));
    x->refc = 1;
    x->decref_fptr = ClosureDecref66;
    x->fptr = ClosureMethod66;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody65(Closure65 * x){
    (void)x;
}
void ClosureDecref65(Closure65 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody65(x); free(x); }
}
UH0 * ClosureMethod65(Closure65 * x){
    
    
    ClosureDecref65(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate66();
    
    
    return UH0_Cons(14ull, v0);
}
Fun0 * ClosureCreate65(){
    Closure65 * x = malloc(sizeof(Closure65));
    x->refc = 1;
    x->decref_fptr = ClosureDecref65;
    x->fptr = ClosureMethod65;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody64(Closure64 * x){
    (void)x;
}
void ClosureDecref64(Closure64 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody64(x); free(x); }
}
UH0 * ClosureMethod64(Closure64 * x){
    
    
    ClosureDecref64(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate65();
    
    
    return UH0_Cons(15ull, v0);
}
Fun0 * ClosureCreate64(){
    Closure64 * x = malloc(sizeof(Closure64));
    x->refc = 1;
    x->decref_fptr = ClosureDecref64;
    x->fptr = ClosureMethod64;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody63(Closure63 * x){
    (void)x;
}
void ClosureDecref63(Closure63 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody63(x); free(x); }
}
UH0 * ClosureMethod63(Closure63 * x){
    
    
    ClosureDecref63(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate64();
    
    
    return UH0_Cons(16ull, v0);
}
Fun0 * ClosureCreate63(){
    Closure63 * x = malloc(sizeof(Closure63));
    x->refc = 1;
    x->decref_fptr = ClosureDecref63;
    x->fptr = ClosureMethod63;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody62(Closure62 * x){
    (void)x;
}
void ClosureDecref62(Closure62 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody62(x); free(x); }
}
UH0 * ClosureMethod62(Closure62 * x){
    
    
    ClosureDecref62(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate63();
    
    
    return UH0_Cons(17ull, v0);
}
Fun0 * ClosureCreate62(){
    Closure62 * x = malloc(sizeof(Closure62));
    x->refc = 1;
    x->decref_fptr = ClosureDecref62;
    x->fptr = ClosureMethod62;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody61(Closure61 * x){
    (void)x;
}
void ClosureDecref61(Closure61 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody61(x); free(x); }
}
UH0 * ClosureMethod61(Closure61 * x){
    
    
    ClosureDecref61(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate62();
    
    
    return UH0_Cons(18ull, v0);
}
Fun0 * ClosureCreate61(){
    Closure61 * x = malloc(sizeof(Closure61));
    x->refc = 1;
    x->decref_fptr = ClosureDecref61;
    x->fptr = ClosureMethod61;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody60(Closure60 * x){
    (void)x;
}
void ClosureDecref60(Closure60 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody60(x); free(x); }
}
UH0 * ClosureMethod60(Closure60 * x){
    
    
    ClosureDecref60(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate61();
    
    
    return UH0_Cons(19ull, v0);
}
Fun0 * ClosureCreate60(){
    Closure60 * x = malloc(sizeof(Closure60));
    x->refc = 1;
    x->decref_fptr = ClosureDecref60;
    x->fptr = ClosureMethod60;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody59(Closure59 * x){
    (void)x;
}
void ClosureDecref59(Closure59 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody59(x); free(x); }
}
UH0 * ClosureMethod59(Closure59 * x){
    
    
    ClosureDecref59(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate60();
    
    
    return UH0_Cons(20ull, v0);
}
Fun0 * ClosureCreate59(){
    Closure59 * x = malloc(sizeof(Closure59));
    x->refc = 1;
    x->decref_fptr = ClosureDecref59;
    x->fptr = ClosureMethod59;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody58(Closure58 * x){
    (void)x;
}
void ClosureDecref58(Closure58 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody58(x); free(x); }
}
UH0 * ClosureMethod58(Closure58 * x){
    
    
    ClosureDecref58(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate59();
    
    
    return UH0_Cons(21ull, v0);
}
Fun0 * ClosureCreate58(){
    Closure58 * x = malloc(sizeof(Closure58));
    x->refc = 1;
    x->decref_fptr = ClosureDecref58;
    x->fptr = ClosureMethod58;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody57(Closure57 * x){
    (void)x;
}
void ClosureDecref57(Closure57 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody57(x); free(x); }
}
UH0 * ClosureMethod57(Closure57 * x){
    
    
    ClosureDecref57(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate58();
    
    
    return UH0_Cons(22ull, v0);
}
Fun0 * ClosureCreate57(){
    Closure57 * x = malloc(sizeof(Closure57));
    x->refc = 1;
    x->decref_fptr = ClosureDecref57;
    x->fptr = ClosureMethod57;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody56(Closure56 * x){
    (void)x;
}
void ClosureDecref56(Closure56 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody56(x); free(x); }
}
UH0 * ClosureMethod56(Closure56 * x){
    
    
    ClosureDecref56(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate57();
    
    
    return UH0_Cons(23ull, v0);
}
Fun0 * ClosureCreate56(){
    Closure56 * x = malloc(sizeof(Closure56));
    x->refc = 1;
    x->decref_fptr = ClosureDecref56;
    x->fptr = ClosureMethod56;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody55(Closure55 * x){
    (void)x;
}
void ClosureDecref55(Closure55 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody55(x); free(x); }
}
UH0 * ClosureMethod55(Closure55 * x){
    
    
    ClosureDecref55(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate56();
    
    
    return UH0_Cons(24ull, v0);
}
Fun0 * ClosureCreate55(){
    Closure55 * x = malloc(sizeof(Closure55));
    x->refc = 1;
    x->decref_fptr = ClosureDecref55;
    x->fptr = ClosureMethod55;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody54(Closure54 * x){
    (void)x;
}
void ClosureDecref54(Closure54 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody54(x); free(x); }
}
UH0 * ClosureMethod54(Closure54 * x){
    
    
    ClosureDecref54(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate55();
    
    
    return UH0_Cons(25ull, v0);
}
Fun0 * ClosureCreate54(){
    Closure54 * x = malloc(sizeof(Closure54));
    x->refc = 1;
    x->decref_fptr = ClosureDecref54;
    x->fptr = ClosureMethod54;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody53(Closure53 * x){
    (void)x;
}
void ClosureDecref53(Closure53 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody53(x); free(x); }
}
UH0 * ClosureMethod53(Closure53 * x){
    
    
    ClosureDecref53(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate54();
    
    
    return UH0_Cons(26ull, v0);
}
Fun0 * ClosureCreate53(){
    Closure53 * x = malloc(sizeof(Closure53));
    x->refc = 1;
    x->decref_fptr = ClosureDecref53;
    x->fptr = ClosureMethod53;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody52(Closure52 * x){
    (void)x;
}
void ClosureDecref52(Closure52 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody52(x); free(x); }
}
UH0 * ClosureMethod52(Closure52 * x){
    
    
    ClosureDecref52(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate53();
    
    
    return UH0_Cons(27ull, v0);
}
Fun0 * ClosureCreate52(){
    Closure52 * x = malloc(sizeof(Closure52));
    x->refc = 1;
    x->decref_fptr = ClosureDecref52;
    x->fptr = ClosureMethod52;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody51(Closure51 * x){
    (void)x;
}
void ClosureDecref51(Closure51 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody51(x); free(x); }
}
UH0 * ClosureMethod51(Closure51 * x){
    
    
    ClosureDecref51(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate52();
    
    
    return UH0_Cons(28ull, v0);
}
Fun0 * ClosureCreate51(){
    Closure51 * x = malloc(sizeof(Closure51));
    x->refc = 1;
    x->decref_fptr = ClosureDecref51;
    x->fptr = ClosureMethod51;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody50(Closure50 * x){
    (void)x;
}
void ClosureDecref50(Closure50 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody50(x); free(x); }
}
UH0 * ClosureMethod50(Closure50 * x){
    
    
    ClosureDecref50(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate51();
    
    
    return UH0_Cons(29ull, v0);
}
Fun0 * ClosureCreate50(){
    Closure50 * x = malloc(sizeof(Closure50));
    x->refc = 1;
    x->decref_fptr = ClosureDecref50;
    x->fptr = ClosureMethod50;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody49(Closure49 * x){
    (void)x;
}
void ClosureDecref49(Closure49 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody49(x); free(x); }
}
UH0 * ClosureMethod49(Closure49 * x){
    
    
    ClosureDecref49(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate50();
    
    
    return UH0_Cons(30ull, v0);
}
Fun0 * ClosureCreate49(){
    Closure49 * x = malloc(sizeof(Closure49));
    x->refc = 1;
    x->decref_fptr = ClosureDecref49;
    x->fptr = ClosureMethod49;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody48(Closure48 * x){
    (void)x;
}
void ClosureDecref48(Closure48 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody48(x); free(x); }
}
UH0 * ClosureMethod48(Closure48 * x){
    
    
    ClosureDecref48(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate49();
    
    
    return UH0_Cons(31ull, v0);
}
Fun0 * ClosureCreate48(){
    Closure48 * x = malloc(sizeof(Closure48));
    x->refc = 1;
    x->decref_fptr = ClosureDecref48;
    x->fptr = ClosureMethod48;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody47(Closure47 * x){
    (void)x;
}
void ClosureDecref47(Closure47 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody47(x); free(x); }
}
UH0 * ClosureMethod47(Closure47 * x){
    
    
    ClosureDecref47(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate48();
    
    
    return UH0_Cons(32ull, v0);
}
Fun0 * ClosureCreate47(){
    Closure47 * x = malloc(sizeof(Closure47));
    x->refc = 1;
    x->decref_fptr = ClosureDecref47;
    x->fptr = ClosureMethod47;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody46(Closure46 * x){
    (void)x;
}
void ClosureDecref46(Closure46 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody46(x); free(x); }
}
UH0 * ClosureMethod46(Closure46 * x){
    
    
    ClosureDecref46(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate47();
    
    
    return UH0_Cons(33ull, v0);
}
Fun0 * ClosureCreate46(){
    Closure46 * x = malloc(sizeof(Closure46));
    x->refc = 1;
    x->decref_fptr = ClosureDecref46;
    x->fptr = ClosureMethod46;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody45(Closure45 * x){
    (void)x;
}
void ClosureDecref45(Closure45 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody45(x); free(x); }
}
UH0 * ClosureMethod45(Closure45 * x){
    
    
    ClosureDecref45(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate46();
    
    
    return UH0_Cons(34ull, v0);
}
Fun0 * ClosureCreate45(){
    Closure45 * x = malloc(sizeof(Closure45));
    x->refc = 1;
    x->decref_fptr = ClosureDecref45;
    x->fptr = ClosureMethod45;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody44(Closure44 * x){
    (void)x;
}
void ClosureDecref44(Closure44 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody44(x); free(x); }
}
UH0 * ClosureMethod44(Closure44 * x){
    
    
    ClosureDecref44(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate45();
    
    
    return UH0_Cons(35ull, v0);
}
Fun0 * ClosureCreate44(){
    Closure44 * x = malloc(sizeof(Closure44));
    x->refc = 1;
    x->decref_fptr = ClosureDecref44;
    x->fptr = ClosureMethod44;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody43(Closure43 * x){
    (void)x;
}
void ClosureDecref43(Closure43 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody43(x); free(x); }
}
UH0 * ClosureMethod43(Closure43 * x){
    
    
    ClosureDecref43(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate44();
    
    
    return UH0_Cons(36ull, v0);
}
Fun0 * ClosureCreate43(){
    Closure43 * x = malloc(sizeof(Closure43));
    x->refc = 1;
    x->decref_fptr = ClosureDecref43;
    x->fptr = ClosureMethod43;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody42(Closure42 * x){
    (void)x;
}
void ClosureDecref42(Closure42 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody42(x); free(x); }
}
UH0 * ClosureMethod42(Closure42 * x){
    
    
    ClosureDecref42(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate43();
    
    
    return UH0_Cons(37ull, v0);
}
Fun0 * ClosureCreate42(){
    Closure42 * x = malloc(sizeof(Closure42));
    x->refc = 1;
    x->decref_fptr = ClosureDecref42;
    x->fptr = ClosureMethod42;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody41(Closure41 * x){
    (void)x;
}
void ClosureDecref41(Closure41 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody41(x); free(x); }
}
UH0 * ClosureMethod41(Closure41 * x){
    
    
    ClosureDecref41(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate42();
    
    
    return UH0_Cons(38ull, v0);
}
Fun0 * ClosureCreate41(){
    Closure41 * x = malloc(sizeof(Closure41));
    x->refc = 1;
    x->decref_fptr = ClosureDecref41;
    x->fptr = ClosureMethod41;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody40(Closure40 * x){
    (void)x;
}
void ClosureDecref40(Closure40 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody40(x); free(x); }
}
UH0 * ClosureMethod40(Closure40 * x){
    
    
    ClosureDecref40(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate41();
    
    
    return UH0_Cons(39ull, v0);
}
Fun0 * ClosureCreate40(){
    Closure40 * x = malloc(sizeof(Closure40));
    x->refc = 1;
    x->decref_fptr = ClosureDecref40;
    x->fptr = ClosureMethod40;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody39(Closure39 * x){
    (void)x;
}
void ClosureDecref39(Closure39 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody39(x); free(x); }
}
UH0 * ClosureMethod39(Closure39 * x){
    
    
    ClosureDecref39(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate40();
    
    
    return UH0_Cons(40ull, v0);
}
Fun0 * ClosureCreate39(){
    Closure39 * x = malloc(sizeof(Closure39));
    x->refc = 1;
    x->decref_fptr = ClosureDecref39;
    x->fptr = ClosureMethod39;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody38(Closure38 * x){
    (void)x;
}
void ClosureDecref38(Closure38 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody38(x); free(x); }
}
UH0 * ClosureMethod38(Closure38 * x){
    
    
    ClosureDecref38(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate39();
    
    
    return UH0_Cons(41ull, v0);
}
Fun0 * ClosureCreate38(){
    Closure38 * x = malloc(sizeof(Closure38));
    x->refc = 1;
    x->decref_fptr = ClosureDecref38;
    x->fptr = ClosureMethod38;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody37(Closure37 * x){
    (void)x;
}
void ClosureDecref37(Closure37 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody37(x); free(x); }
}
UH0 * ClosureMethod37(Closure37 * x){
    
    
    ClosureDecref37(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate38();
    
    
    return UH0_Cons(42ull, v0);
}
Fun0 * ClosureCreate37(){
    Closure37 * x = malloc(sizeof(Closure37));
    x->refc = 1;
    x->decref_fptr = ClosureDecref37;
    x->fptr = ClosureMethod37;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody36(Closure36 * x){
    (void)x;
}
void ClosureDecref36(Closure36 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody36(x); free(x); }
}
UH0 * ClosureMethod36(Closure36 * x){
    
    
    ClosureDecref36(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate37();
    
    
    return UH0_Cons(43ull, v0);
}
Fun0 * ClosureCreate36(){
    Closure36 * x = malloc(sizeof(Closure36));
    x->refc = 1;
    x->decref_fptr = ClosureDecref36;
    x->fptr = ClosureMethod36;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody35(Closure35 * x){
    (void)x;
}
void ClosureDecref35(Closure35 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody35(x); free(x); }
}
UH0 * ClosureMethod35(Closure35 * x){
    
    
    ClosureDecref35(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate36();
    
    
    return UH0_Cons(44ull, v0);
}
Fun0 * ClosureCreate35(){
    Closure35 * x = malloc(sizeof(Closure35));
    x->refc = 1;
    x->decref_fptr = ClosureDecref35;
    x->fptr = ClosureMethod35;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody34(Closure34 * x){
    (void)x;
}
void ClosureDecref34(Closure34 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody34(x); free(x); }
}
UH0 * ClosureMethod34(Closure34 * x){
    
    
    ClosureDecref34(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate35();
    
    
    return UH0_Cons(45ull, v0);
}
Fun0 * ClosureCreate34(){
    Closure34 * x = malloc(sizeof(Closure34));
    x->refc = 1;
    x->decref_fptr = ClosureDecref34;
    x->fptr = ClosureMethod34;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody33(Closure33 * x){
    (void)x;
}
void ClosureDecref33(Closure33 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody33(x); free(x); }
}
UH0 * ClosureMethod33(Closure33 * x){
    
    
    ClosureDecref33(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate34();
    
    
    return UH0_Cons(46ull, v0);
}
Fun0 * ClosureCreate33(){
    Closure33 * x = malloc(sizeof(Closure33));
    x->refc = 1;
    x->decref_fptr = ClosureDecref33;
    x->fptr = ClosureMethod33;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody32(Closure32 * x){
    (void)x;
}
void ClosureDecref32(Closure32 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody32(x); free(x); }
}
UH0 * ClosureMethod32(Closure32 * x){
    
    
    ClosureDecref32(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate33();
    
    
    return UH0_Cons(47ull, v0);
}
Fun0 * ClosureCreate32(){
    Closure32 * x = malloc(sizeof(Closure32));
    x->refc = 1;
    x->decref_fptr = ClosureDecref32;
    x->fptr = ClosureMethod32;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody31(Closure31 * x){
    (void)x;
}
void ClosureDecref31(Closure31 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody31(x); free(x); }
}
UH0 * ClosureMethod31(Closure31 * x){
    
    
    ClosureDecref31(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate32();
    
    
    return UH0_Cons(48ull, v0);
}
Fun0 * ClosureCreate31(){
    Closure31 * x = malloc(sizeof(Closure31));
    x->refc = 1;
    x->decref_fptr = ClosureDecref31;
    x->fptr = ClosureMethod31;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody30(Closure30 * x){
    (void)x;
}
void ClosureDecref30(Closure30 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody30(x); free(x); }
}
UH0 * ClosureMethod30(Closure30 * x){
    
    
    ClosureDecref30(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate31();
    
    
    return UH0_Cons(49ull, v0);
}
Fun0 * ClosureCreate30(){
    Closure30 * x = malloc(sizeof(Closure30));
    x->refc = 1;
    x->decref_fptr = ClosureDecref30;
    x->fptr = ClosureMethod30;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody29(Closure29 * x){
    (void)x;
}
void ClosureDecref29(Closure29 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody29(x); free(x); }
}
UH0 * ClosureMethod29(Closure29 * x){
    
    
    ClosureDecref29(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate30();
    
    
    return UH0_Cons(50ull, v0);
}
Fun0 * ClosureCreate29(){
    Closure29 * x = malloc(sizeof(Closure29));
    x->refc = 1;
    x->decref_fptr = ClosureDecref29;
    x->fptr = ClosureMethod29;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody28(Closure28 * x){
    (void)x;
}
void ClosureDecref28(Closure28 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody28(x); free(x); }
}
UH0 * ClosureMethod28(Closure28 * x){
    
    
    ClosureDecref28(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate29();
    
    
    return UH0_Cons(51ull, v0);
}
Fun0 * ClosureCreate28(){
    Closure28 * x = malloc(sizeof(Closure28));
    x->refc = 1;
    x->decref_fptr = ClosureDecref28;
    x->fptr = ClosureMethod28;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody27(Closure27 * x){
    (void)x;
}
void ClosureDecref27(Closure27 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody27(x); free(x); }
}
UH0 * ClosureMethod27(Closure27 * x){
    
    
    ClosureDecref27(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate28();
    
    
    return UH0_Cons(52ull, v0);
}
Fun0 * ClosureCreate27(){
    Closure27 * x = malloc(sizeof(Closure27));
    x->refc = 1;
    x->decref_fptr = ClosureDecref27;
    x->fptr = ClosureMethod27;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody26(Closure26 * x){
    (void)x;
}
void ClosureDecref26(Closure26 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody26(x); free(x); }
}
UH0 * ClosureMethod26(Closure26 * x){
    
    
    ClosureDecref26(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate27();
    
    
    return UH0_Cons(53ull, v0);
}
Fun0 * ClosureCreate26(){
    Closure26 * x = malloc(sizeof(Closure26));
    x->refc = 1;
    x->decref_fptr = ClosureDecref26;
    x->fptr = ClosureMethod26;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody25(Closure25 * x){
    (void)x;
}
void ClosureDecref25(Closure25 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody25(x); free(x); }
}
UH0 * ClosureMethod25(Closure25 * x){
    
    
    ClosureDecref25(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate26();
    
    
    return UH0_Cons(54ull, v0);
}
Fun0 * ClosureCreate25(){
    Closure25 * x = malloc(sizeof(Closure25));
    x->refc = 1;
    x->decref_fptr = ClosureDecref25;
    x->fptr = ClosureMethod25;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody24(Closure24 * x){
    (void)x;
}
void ClosureDecref24(Closure24 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody24(x); free(x); }
}
UH0 * ClosureMethod24(Closure24 * x){
    
    
    ClosureDecref24(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate25();
    
    
    return UH0_Cons(55ull, v0);
}
Fun0 * ClosureCreate24(){
    Closure24 * x = malloc(sizeof(Closure24));
    x->refc = 1;
    x->decref_fptr = ClosureDecref24;
    x->fptr = ClosureMethod24;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody23(Closure23 * x){
    (void)x;
}
void ClosureDecref23(Closure23 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody23(x); free(x); }
}
UH0 * ClosureMethod23(Closure23 * x){
    
    
    ClosureDecref23(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate24();
    
    
    return UH0_Cons(56ull, v0);
}
Fun0 * ClosureCreate23(){
    Closure23 * x = malloc(sizeof(Closure23));
    x->refc = 1;
    x->decref_fptr = ClosureDecref23;
    x->fptr = ClosureMethod23;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody22(Closure22 * x){
    (void)x;
}
void ClosureDecref22(Closure22 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody22(x); free(x); }
}
UH0 * ClosureMethod22(Closure22 * x){
    
    
    ClosureDecref22(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate23();
    
    
    return UH0_Cons(57ull, v0);
}
Fun0 * ClosureCreate22(){
    Closure22 * x = malloc(sizeof(Closure22));
    x->refc = 1;
    x->decref_fptr = ClosureDecref22;
    x->fptr = ClosureMethod22;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody21(Closure21 * x){
    (void)x;
}
void ClosureDecref21(Closure21 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody21(x); free(x); }
}
UH0 * ClosureMethod21(Closure21 * x){
    
    
    ClosureDecref21(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate22();
    
    
    return UH0_Cons(58ull, v0);
}
Fun0 * ClosureCreate21(){
    Closure21 * x = malloc(sizeof(Closure21));
    x->refc = 1;
    x->decref_fptr = ClosureDecref21;
    x->fptr = ClosureMethod21;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody20(Closure20 * x){
    (void)x;
}
void ClosureDecref20(Closure20 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody20(x); free(x); }
}
UH0 * ClosureMethod20(Closure20 * x){
    
    
    ClosureDecref20(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate21();
    
    
    return UH0_Cons(59ull, v0);
}
Fun0 * ClosureCreate20(){
    Closure20 * x = malloc(sizeof(Closure20));
    x->refc = 1;
    x->decref_fptr = ClosureDecref20;
    x->fptr = ClosureMethod20;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody19(Closure19 * x){
    (void)x;
}
void ClosureDecref19(Closure19 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody19(x); free(x); }
}
UH0 * ClosureMethod19(Closure19 * x){
    
    
    ClosureDecref19(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate20();
    
    
    return UH0_Cons(60ull, v0);
}
Fun0 * ClosureCreate19(){
    Closure19 * x = malloc(sizeof(Closure19));
    x->refc = 1;
    x->decref_fptr = ClosureDecref19;
    x->fptr = ClosureMethod19;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody18(Closure18 * x){
    (void)x;
}
void ClosureDecref18(Closure18 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody18(x); free(x); }
}
UH0 * ClosureMethod18(Closure18 * x){
    
    
    ClosureDecref18(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate19();
    
    
    return UH0_Cons(61ull, v0);
}
Fun0 * ClosureCreate18(){
    Closure18 * x = malloc(sizeof(Closure18));
    x->refc = 1;
    x->decref_fptr = ClosureDecref18;
    x->fptr = ClosureMethod18;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody17(Closure17 * x){
    (void)x;
}
void ClosureDecref17(Closure17 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody17(x); free(x); }
}
UH0 * ClosureMethod17(Closure17 * x){
    
    
    ClosureDecref17(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate18();
    
    
    return UH0_Cons(62ull, v0);
}
Fun0 * ClosureCreate17(){
    Closure17 * x = malloc(sizeof(Closure17));
    x->refc = 1;
    x->decref_fptr = ClosureDecref17;
    x->fptr = ClosureMethod17;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody16(Closure16 * x){
    (void)x;
}
void ClosureDecref16(Closure16 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody16(x); free(x); }
}
UH0 * ClosureMethod16(Closure16 * x){
    
    
    ClosureDecref16(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate17();
    
    
    return UH0_Cons(63ull, v0);
}
Fun0 * ClosureCreate16(){
    Closure16 * x = malloc(sizeof(Closure16));
    x->refc = 1;
    x->decref_fptr = ClosureDecref16;
    x->fptr = ClosureMethod16;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody15(Closure15 * x){
    (void)x;
}
void ClosureDecref15(Closure15 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody15(x); free(x); }
}
UH0 * ClosureMethod15(Closure15 * x){
    
    
    ClosureDecref15(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate16();
    
    
    return UH0_Cons(64ull, v0);
}
Fun0 * ClosureCreate15(){
    Closure15 * x = malloc(sizeof(Closure15));
    x->refc = 1;
    x->decref_fptr = ClosureDecref15;
    x->fptr = ClosureMethod15;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody14(Closure14 * x){
    (void)x;
}
void ClosureDecref14(Closure14 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody14(x); free(x); }
}
UH0 * ClosureMethod14(Closure14 * x){
    
    
    ClosureDecref14(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate15();
    
    
    return UH0_Cons(65ull, v0);
}
Fun0 * ClosureCreate14(){
    Closure14 * x = malloc(sizeof(Closure14));
    x->refc = 1;
    x->decref_fptr = ClosureDecref14;
    x->fptr = ClosureMethod14;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody13(Closure13 * x){
    (void)x;
}
void ClosureDecref13(Closure13 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody13(x); free(x); }
}
UH0 * ClosureMethod13(Closure13 * x){
    
    
    ClosureDecref13(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate14();
    
    
    return UH0_Cons(66ull, v0);
}
Fun0 * ClosureCreate13(){
    Closure13 * x = malloc(sizeof(Closure13));
    x->refc = 1;
    x->decref_fptr = ClosureDecref13;
    x->fptr = ClosureMethod13;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody12(Closure12 * x){
    (void)x;
}
void ClosureDecref12(Closure12 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody12(x); free(x); }
}
UH0 * ClosureMethod12(Closure12 * x){
    
    
    ClosureDecref12(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate13();
    
    
    return UH0_Cons(67ull, v0);
}
Fun0 * ClosureCreate12(){
    Closure12 * x = malloc(sizeof(Closure12));
    x->refc = 1;
    x->decref_fptr = ClosureDecref12;
    x->fptr = ClosureMethod12;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody11(Closure11 * x){
    (void)x;
}
void ClosureDecref11(Closure11 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody11(x); free(x); }
}
UH0 * ClosureMethod11(Closure11 * x){
    
    
    ClosureDecref11(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate12();
    
    
    return UH0_Cons(68ull, v0);
}
Fun0 * ClosureCreate11(){
    Closure11 * x = malloc(sizeof(Closure11));
    x->refc = 1;
    x->decref_fptr = ClosureDecref11;
    x->fptr = ClosureMethod11;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody10(Closure10 * x){
    (void)x;
}
void ClosureDecref10(Closure10 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody10(x); free(x); }
}
UH0 * ClosureMethod10(Closure10 * x){
    
    
    ClosureDecref10(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate11();
    
    
    return UH0_Cons(69ull, v0);
}
Fun0 * ClosureCreate10(){
    Closure10 * x = malloc(sizeof(Closure10));
    x->refc = 1;
    x->decref_fptr = ClosureDecref10;
    x->fptr = ClosureMethod10;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody9(Closure9 * x){
    (void)x;
}
void ClosureDecref9(Closure9 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody9(x); free(x); }
}
UH0 * ClosureMethod9(Closure9 * x){
    
    
    ClosureDecref9(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate10();
    
    
    return UH0_Cons(70ull, v0);
}
Fun0 * ClosureCreate9(){
    Closure9 * x = malloc(sizeof(Closure9));
    x->refc = 1;
    x->decref_fptr = ClosureDecref9;
    x->fptr = ClosureMethod9;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody8(Closure8 * x){
    (void)x;
}
void ClosureDecref8(Closure8 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody8(x); free(x); }
}
UH0 * ClosureMethod8(Closure8 * x){
    
    
    ClosureDecref8(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate9();
    
    
    return UH0_Cons(71ull, v0);
}
Fun0 * ClosureCreate8(){
    Closure8 * x = malloc(sizeof(Closure8));
    x->refc = 1;
    x->decref_fptr = ClosureDecref8;
    x->fptr = ClosureMethod8;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody7(Closure7 * x){
    (void)x;
}
void ClosureDecref7(Closure7 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody7(x); free(x); }
}
UH0 * ClosureMethod7(Closure7 * x){
    
    
    ClosureDecref7(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate8();
    
    
    return UH0_Cons(72ull, v0);
}
Fun0 * ClosureCreate7(){
    Closure7 * x = malloc(sizeof(Closure7));
    x->refc = 1;
    x->decref_fptr = ClosureDecref7;
    x->fptr = ClosureMethod7;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody6(Closure6 * x){
    (void)x;
}
void ClosureDecref6(Closure6 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody6(x); free(x); }
}
UH0 * ClosureMethod6(Closure6 * x){
    
    
    ClosureDecref6(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate7();
    
    
    return UH0_Cons(73ull, v0);
}
Fun0 * ClosureCreate6(){
    Closure6 * x = malloc(sizeof(Closure6));
    x->refc = 1;
    x->decref_fptr = ClosureDecref6;
    x->fptr = ClosureMethod6;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody5(Closure5 * x){
    (void)x;
}
void ClosureDecref5(Closure5 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody5(x); free(x); }
}
UH0 * ClosureMethod5(Closure5 * x){
    
    
    ClosureDecref5(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate6();
    
    
    return UH0_Cons(74ull, v0);
}
Fun0 * ClosureCreate5(){
    Closure5 * x = malloc(sizeof(Closure5));
    x->refc = 1;
    x->decref_fptr = ClosureDecref5;
    x->fptr = ClosureMethod5;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody4(Closure4 * x){
    (void)x;
}
void ClosureDecref4(Closure4 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody4(x); free(x); }
}
UH0 * ClosureMethod4(Closure4 * x){
    
    
    ClosureDecref4(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate5();
    
    
    return UH0_Cons(75ull, v0);
}
Fun0 * ClosureCreate4(){
    Closure4 * x = malloc(sizeof(Closure4));
    x->refc = 1;
    x->decref_fptr = ClosureDecref4;
    x->fptr = ClosureMethod4;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody3(Closure3 * x){
    (void)x;
}
void ClosureDecref3(Closure3 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody3(x); free(x); }
}
UH0 * ClosureMethod3(Closure3 * x){
    
    
    ClosureDecref3(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate4();
    
    
    return UH0_Cons(76ull, v0);
}
Fun0 * ClosureCreate3(){
    Closure3 * x = malloc(sizeof(Closure3));
    x->refc = 1;
    x->decref_fptr = ClosureDecref3;
    x->fptr = ClosureMethod3;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody2(Closure2 * x){
    (void)x;
}
void ClosureDecref2(Closure2 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody2(x); free(x); }
}
UH0 * ClosureMethod2(Closure2 * x){
    
    
    ClosureDecref2(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate3();
    
    
    return UH0_Cons(77ull, v0);
}
Fun0 * ClosureCreate2(){
    Closure2 * x = malloc(sizeof(Closure2));
    x->refc = 1;
    x->decref_fptr = ClosureDecref2;
    x->fptr = ClosureMethod2;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody1(Closure1 * x){
    (void)x;
}
void ClosureDecref1(Closure1 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody1(x); free(x); }
}
UH0 * ClosureMethod1(Closure1 * x){
    
    
    ClosureDecref1(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate2();
    
    
    return UH0_Cons(78ull, v0);
}
Fun0 * ClosureCreate1(){
    Closure1 * x = malloc(sizeof(Closure1));
    x->refc = 1;
    x->decref_fptr = ClosureDecref1;
    x->fptr = ClosureMethod1;
    
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody0(Closure0 * x){
    (void)x;
}
void ClosureDecref0(Closure0 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
UH0 * ClosureMethod0(Closure0 * x){
    
    
    ClosureDecref0(x);
    
    
    Fun0 * v0;
    v0 = ClosureCreate1();
    
    
    return UH0_Cons(79ull, v0);
}
Fun0 * ClosureCreate0(){
    Closure0 * x = malloc(sizeof(Closure0));
    x->refc = 1;
    x->decref_fptr = ClosureDecref0;
    x->fptr = ClosureMethod0;
    
    return (Fun0 *) x;
}
uint64_t loop0(UH0 * v0, uint64_t v1){
    
    
    switch (v0->tag) {
        case 0: { // Cons
            uint64_t v2 = v0->case0.v0; Fun0 * v3 = v0->case0.v1;
            v3->refc += 2;
            UHDecref0(v0);
            UH0 * v4;
            v4 = v3->fptr(v3);
            
            v3->decref_fptr(v3);
            uint64_t v5;
            v5 = v1 + v2;
            
            
            return loop0(v4, v5);
            break;
        }
        case 1: { // Nil
            
            
            UHDecref0(v0);
            return v1;
            break;
        }
    }
}
int32_t main(){
    
    
    uint64_t v0;
    v0 = 80ull;
    
    
    Fun0 * v1;
    v1 = ClosureCreate0();
    v1->refc++;
    
    UH0 * v2;
    v2 = UH0_Cons(v0, v1);
    
    v1->decref_fptr(v1);
    uint64_t v3;
    v3 = 0ull;
    v2->refc++;
    
    uint64_t v4;
    v4 = loop0(v2, v3);
    
    UHDecref0(v2);
    uint64_t v5;
    v5 = v4 % 200ull;
    
    
    int32_t v6;
    v6 = (int32_t)v5;
    
    
    return v6;
}
