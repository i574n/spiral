import re
import sys
from pathlib import Path

lib = Path(__file__).resolve().parents[4] / "lib" / "spiral"
apply = "--apply" in sys.argv

candidates = {
    "sm'.spi": "index_of_char is_white_space builder_append_line char_is_alphanumeric os_string_as_ref base64_decode utf8_decode",
    "runtime.spi": "arg_overrides_with arg_num_args arg_value_name value_parser_path_buf value_parser_expr matches_get_occurrences matches_values_of new_process process_start process_exit_code process_has_exited process_kill process_begin_error_read_line process_begin_output_read_line process_add_output_data_received process_add_error_data_received process_wait_for_exit_async event_data execute_retry",
    "file_system.spi": "file_stream directory_info_exists directory_info_creation_time file_move path_buf_from path_buf_strip_prefix path_display path_buf_is_symlink get_directory_name init_trace_file",
    "threading.spi": "new_mutex_mut new_arc_rw_lock arc_clone arc_try_unwrap arc_into_raw arc_from_raw arc_rw_lock_read arc_rw_lock_write arc_rw_lock_try_read arc_rw_lock_try_write rw_lock_read_guard_ref rw_lock_write_guard_ref mutex_guard_as_mut concurrent_stack_push token_none new_concurrent_stack token_register",
    "async.spi": "block_on_futures_lite block_on_async_std block_on_tokio_send stream_collect_tokio stream_next_tokio stream_filter_map_tokio spawn_tokio future_fuse join_all_send await_handle await_all await_all_send try_await_all_send try_join_all_iter start_child start_child_timeout start_immediate start_with_continuations return_await default_cancellation_token await_value_task_unit",
}

def definition_range(lines, name):
    header = f"/// ### {name}"
    definition = re.compile(rf"(inl|let|nominal|type|union)( rec)? {re.escape(name)}\b")
    headers = [i for i, line in enumerate(lines) if line.rstrip() == header]
    if len(headers) > 1:
        return None, f"header found {len(headers)} times", 0
    if headers:
        start, body = headers[0], headers[0] + 1
        if body >= len(lines) or not definition.match(lines[body]):
            return None, f"line after header is not its definition: {lines[body][:60]!r}", 0
    else:
        bare = [i for i, line in enumerate(lines) if definition.match(line)]
        if len(bare) != 1:
            return None, f"no header and {len(bare)} bare definitions", 0
        start = body = bare[0]
    end = body + 1
    while end < len(lines) and (lines[end].startswith((" ", "\t")) or (lines[end] == "" and end + 1 < len(lines) and lines[end + 1].startswith((" ", "\t")))):
        end += 1
    while end < len(lines) and lines[end] == "":
        end += 1
    return (start, end), None, len(headers) + 1

total = 0
failures = 0
plans = []
for file_name, names in candidates.items():
    path = lib / file_name
    text = path.read_text(encoding="utf-8")
    if "\r" in text:
        sys.exit(f"{file_name}: CR found")
    lines = text.split("\n")
    ranges = []
    for name in names.split():
        found, problem, expected = definition_range(lines, name)
        if problem:
            print(f"{file_name} {name}: {problem}")
            failures += 1
            continue
        uses = sum(len(re.findall(rf"(?<![\w']){re.escape(name)}(?![\w'])", line)) for line in lines)
        if uses != expected:
            print(f"{file_name} {name}: {uses} occurrences in its file (expected {expected})")
            failures += 1
            continue
        ranges.append((name, found))
        total += found[1] - found[0]
        print(f"{file_name} {name}: lines {found[0] + 1}-{found[1]} ({found[1] - found[0]} lines)")
    plans.append((path, lines, ranges))
if apply and not failures:
    for path, lines, ranges in plans:
        keep = set(range(len(lines)))
        for _, (start, end) in ranges:
            keep -= set(range(start, end))
        path.write_bytes("\n".join(line for i, line in enumerate(lines) if i in keep).encode("utf-8"))
print(f"{total} lines in {sum(len(n.split()) for n in candidates.values())} definitions, {failures} problems" + ("" if apply else " (dry run, pass --apply to write; needs the census confirmation and an evidence note first)"))
if failures:
    sys.exit(1)
