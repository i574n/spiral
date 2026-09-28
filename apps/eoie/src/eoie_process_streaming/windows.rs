// Spawn suspended, attach to a job, then resume: descendants cannot escape
// between process creation and job assignment. No external taskkill dependency.
use std::ffi::c_void;
use std::os::windows::io::{AsRawHandle, FromRawHandle, OwnedHandle};
use std::os::windows::process::CommandExt;
type Handle = *mut c_void;
#[repr(C)]
#[derive(Default)]
struct BasicLimits { process_time: i64, job_time: i64, flags: u32, min_ws: usize, max_ws: usize, active: u32, affinity: usize, priority: u32, scheduling: u32 }
#[repr(C)]
#[derive(Default)]
struct ExtendedLimits { basic: BasicLimits, io: [u64; 6], process_memory: usize, job_memory: usize, peak_process: usize, peak_job: usize }
#[repr(C)]
struct ThreadEntry { size: u32, usage: u32, id: u32, owner: u32, priority: i32, delta: i32, flags: u32 }
#[link(name = "kernel32")]
unsafe extern "system" {
    fn CreateJobObjectW(attributes: *const c_void, name: *const u16) -> Handle;
    fn SetInformationJobObject(job: Handle, class: i32, info: *const c_void, size: u32) -> i32;
    fn AssignProcessToJobObject(job: Handle, process: Handle) -> i32;
    fn TerminateJobObject(job: Handle, code: u32) -> i32;
    fn CreateToolhelp32Snapshot(flags: u32, pid: u32) -> Handle;
    fn Thread32First(snapshot: Handle, entry: *mut ThreadEntry) -> i32;
    fn Thread32Next(snapshot: Handle, entry: *mut ThreadEntry) -> i32;
    fn OpenThread(access: u32, inherit: i32, id: u32) -> Handle;
    fn ResumeThread(thread: Handle) -> u32;
}
pub struct WindowsJob(OwnedHandle);
impl WindowsJob {
    pub fn spawn(command: &mut std::process::Command) -> Result<(std::process::Child, Self), String> {
        let raw = unsafe { CreateJobObjectW(std::ptr::null(), std::ptr::null()) };
        if raw.is_null() { return Err(format!("create process job: {}", std::io::Error::last_os_error())); }
        let job = Self(unsafe { OwnedHandle::from_raw_handle(raw) });
        let mut limits = ExtendedLimits::default();
        limits.basic.flags = 0x2000; // JOB_OBJECT_LIMIT_KILL_ON_JOB_CLOSE
        if unsafe { SetInformationJobObject(raw, 9, &limits as *const _ as *const c_void, std::mem::size_of_val(&limits) as u32) } == 0 {
            return Err(format!("configure process job: {}", std::io::Error::last_os_error()));
        }
        command.creation_flags(0x08000004); // CREATE_NO_WINDOW | CREATE_SUSPENDED
        let result = command.spawn();
        command.creation_flags(0); // the caller may reuse its Command
        let mut child = result.map_err(|e| format!("spawn process: {e}"))?;
        let result = (|| {
            if unsafe { AssignProcessToJobObject(raw, child.as_raw_handle()) } == 0 {
                return Err(format!("assign process job: {}", std::io::Error::last_os_error()));
            }
            let snapshot = unsafe { CreateToolhelp32Snapshot(4, 0) };
            if snapshot as isize == -1 { return Err(format!("enumerate suspended thread: {}", std::io::Error::last_os_error())); }
            let snapshot = unsafe { OwnedHandle::from_raw_handle(snapshot) };
            let mut entry = ThreadEntry { size: std::mem::size_of::<ThreadEntry>() as u32, usage: 0, id: 0, owner: 0, priority: 0, delta: 0, flags: 0 };
            let mut found = unsafe { Thread32First(snapshot.as_raw_handle(), &mut entry) };
            while found != 0 {
                if entry.owner == child.id() {
                    let thread = unsafe { OpenThread(2, 0, entry.id) };
                    if thread.is_null() { return Err(format!("open suspended thread: {}", std::io::Error::last_os_error())); }
                    let thread = unsafe { OwnedHandle::from_raw_handle(thread) };
                    if unsafe { ResumeThread(thread.as_raw_handle()) } == u32::MAX { return Err(format!("resume process: {}", std::io::Error::last_os_error())); }
                    return Ok(());
                }
                entry.size = std::mem::size_of::<ThreadEntry>() as u32;
                found = unsafe { Thread32Next(snapshot.as_raw_handle(), &mut entry) };
            }
            Err("suspended process thread not found".to_owned())
        })();
        if let Err(e) = result { let _ = child.kill(); let _ = child.wait(); return Err(e); }
        Ok((child, job))
    }
    pub fn terminate(&self) { unsafe { TerminateJobObject(self.0.as_raw_handle(), 1); } }
}
