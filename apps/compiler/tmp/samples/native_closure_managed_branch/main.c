#include <stdbool.h>
#include <stdint.h>
#include <string.h>

typedef struct {
    const char * captured;
    int32_t bias;
} SpiralManagedClosure;

static int32_t SpiralManagedClosureInvoke(const SpiralManagedClosure * closure, int32_t value) {
    return (int32_t)strlen(closure->captured) + value + closure->bias;
}

int32_t main() {
    const bool flag = true;
    const SpiralManagedClosure left = {"abc", 0};
    const SpiralManagedClosure right = {"wxyz", -1};
    const SpiralManagedClosure selected = flag ? left : right;
    return SpiralManagedClosureInvoke(&selected, 39);
}
