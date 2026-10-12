"""Summarize an evented speedscope JSON from dotnet-trace: busy threads, hot leaf frames, hot compiler frames.
Time between events is attributed to the stack open at that point; stacks whose leaf is a wait are skipped."""
import json, re, sys
from collections import Counter

data = json.load(open(sys.argv[1], encoding="utf-8"))
frames = [f["name"] for f in data["shared"]["frames"]]
WAIT = re.compile(r"Wait|Sleep|Monitor\.Enter|SpinWait|Poll|UNMANAGED_CODE_TIME|ReadFile|Idle|Park|Blocking|Thread\.Join|Receive", re.I)

def short(n):
    n = re.sub(r"\(.*$", "", n)
    n = n.replace("SpiralCompilerCore!Polyglot.spiral_compiler+", "").replace("SpiralCompilerCore!Polyglot.spiral_compiler.", "")
    n = re.sub(r"@\d+[-\d]*", "", n)
    return n[:150]

names = [short(f) for f in frames]
is_core = ["SpiralCompiler" in f for f in frames]
leaf, incl, core_leaf = Counter(), Counter(), Counter()
threads = []
for prof in data["profiles"]:
    stack, last, busy = [], None, 0.0
    for ev in prof["events"]:
        at = ev["at"]
        if stack and last is not None and at > last and not WAIT.search(frames[stack[-1]]):
            dt = at - last
            busy += dt
            leaf[names[stack[-1]]] += dt
            for idx in reversed(stack):
                if is_core[idx]:
                    core_leaf[names[idx]] += dt
                    break
            for name in {names[i] for i in stack if is_core[i]}:
                incl[name] += dt
        last = at
        if ev["type"] == "O":
            stack.append(ev["frame"])
        elif stack:
            # close the frame (normally the top)
            if stack[-1] == ev["frame"]:
                stack.pop()
            elif ev["frame"] in stack:
                del stack[len(stack) - 1 - stack[::-1].index(ev["frame"]):]
    threads.append((busy, prof.get("name", "?")))

total = sum(b for b, _ in threads) or 1
print(f"busy total {total:.0f} {data['profiles'][0].get('unit')} over {len(threads)} threads")
for b, n in sorted(threads, reverse=True)[:8]:
    print(f"  {b:9.0f}  {n}")
print("== hot leaf frames (any code)")
for n, w in leaf.most_common(15):
    print(f"  {w/total*100:5.1f}%  {n}")
print("== innermost compiler frame")
for n, w in core_leaf.most_common(25):
    print(f"  {w/total*100:5.1f}%  {n}")
print("== inclusive compiler frames")
for n, w in incl.most_common(45):
    print(f"  {w/total*100:5.1f}%  {n}")
