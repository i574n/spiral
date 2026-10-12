"""Inclusive time per compiler frame on the busiest thread(s) of an evented speedscope profile (dotnet-trace
--format Speedscope). Usage: profile-thread.py <file.speedscope.json> [threads=1] [rows=40]
Recursive frames count once; time whose innermost frame is a wait is not counted. O(1) per event: a running
busy-time clock is sampled when a frame name enters the stack and credited when its last instance leaves."""
import json, re, sys
from collections import Counter, defaultdict

data = json.load(open(sys.argv[1], encoding="utf-8"))
top_threads = int(sys.argv[2]) if len(sys.argv) > 2 else 1
rows = int(sys.argv[3]) if len(sys.argv) > 3 else 40
frames = [f["name"] for f in data["shared"]["frames"]]
WAIT = re.compile(r"Wait|Sleep|Monitor\.Enter|SpinWait|Poll|UNMANAGED_CODE_TIME|Idle|Park|Blocking|Thread\.Join", re.I)

def short(n):
    n = re.sub(r"\(.*$", "", n)
    n = n.replace("SpiralCompilerCore!Polyglot.spiral_compiler+", "").replace("SpiralCompilerCore!Polyglot.spiral_compiler.", "")
    return re.sub(r"@\d+[-\d]*", "", n)[:120]

names = [short(n) for n in frames]
name_ids = {}
frame_name = [name_ids.setdefault(n, len(name_ids)) for n in names]
id_names = {v: k for k, v in name_ids.items()}
is_wait = [bool(WAIT.search(f)) for f in frames]

results = []
for prof in data["profiles"]:
    stack, last, busy = [], None, 0.0
    depth = defaultdict(int)
    entered = {}
    incl = Counter()
    for ev in prof["events"]:
        t = ev["at"]
        if last is not None and stack and not is_wait[stack[-1]]:
            busy += t - last
        last = t
        f = ev["frame"]
        n = frame_name[f]
        if ev["type"] == "O":
            stack.append(f)
            depth[n] += 1
            if depth[n] == 1:
                entered[n] = busy
        elif ev["type"] == "C" and stack:
            stack.pop()
            depth[n] -= 1
            if depth[n] == 0:
                incl[n] += busy - entered.pop(n, busy)
    for n, d in depth.items():
        if d > 0:
            incl[n] += busy - entered.get(n, busy)
    results.append((busy, prof.get("name", "?"), incl))

results.sort(key=lambda x: -x[0])
for busy, name, incl in results[:top_threads]:
    print(f"== {name}: busy {busy:.0f} ms")
    shown = 0
    for n, v in incl.most_common():
        frame = id_names[n]
        if "!" in frame and "SpiralCompilerCore" not in frame:
            continue
        print(f"  {100*v/max(busy,1):5.1f}%  {frame}")
        shown += 1
        if shown >= rows:
            break
