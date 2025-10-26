function FixRust {
    param (
        [Parameter(Mandatory, ValueFromPipeline)]
        $text
    )
            # -replace "_self.", "self." `
            # -replace "_self_.", "self." `
            # -replace "use fable_library_rust::System::Collections::Generic::", "use fable_library_rust::Interfaces_::System::Collections::Generic::" `
            # -replace "use fable_library_rust::System::IDisposable;", "use fable_library_rust::Interfaces_::System::IDisposable;" `
            #
            # -replace [regex]::Escape("),);"), "));" `
            # -replace "__self__.", "self." `
            # -replace "null::<\(\)>\(\)", "null()" `
            # -replace "unbox::<bool>\(null\(\)\)", "false" `
            # -replace "unbox::<string>\(null\(\)\)", "fable_library_rust::Native_::getZero()" `
            # -replace "unbox::<i32>\(null\(\)\)", "0" `
            # -replace "null\(\)", "fable_library_rust::Native_::getZero()" `
            # -replace "([^=]\s)fable_library_rust::Native_::getZero\(\);", "`$1fable_library_rust::Native_::getZero::<()>();" `
            # -replace "use fable_library_rust::System::Collections::Concurrent::ConcurrentStack_1;", "type ConcurrentStack_1<T> = T;" `
            # -replace "use fable_library_rust::System::Threading::Tasks::TaskCanceledException;", "type TaskCanceledException = ();" `
            # -replace "use fable_library_rust::System::TimeZoneInfo;", "type TimeZoneInfo = i64;"
    process {
        $text `
            -replace [regex]::Escape("),);"), "));" `
            -replace [regex]::Escape("},);"), "});" `
            -replace "get_or_insert_with", "get_or_init" `
            -replace "([^=]\s)defaultOf\(\);", "`$1`defaultOf::<()>();" `
            -replace "([^=]\s)getZero\(\);", "`$1`getZero::<()>();" `
            -replace "getNull::", "&getNull::" `
            -replace "&getNull::<\(\)>\(\)", "fable_library_rust::Native_::getZero()" `
            -replace "\(null::<\(\)>\(\)", "(null()" `
            -replace " null::<\(\)>\(\)", " null()" `
            -replace "unbox::<bool>\(null\(\)\)", "false" `
            -replace "unbox::<string>\(null\(\)\)", "fable_library_rust::Native_::getZero()" `
            -replace "unbox::<i32>\(null\(\)\)", "0" `
            -replace "null\(\)", "fable_library_rust::Native_::getZero()" `
            -replace "([^=]\s)fable_library_rust::Native_::getZero\(\);", "`$1fable_library_rust::Native_::getZero::<()>();" `
            -replace "__self__.", "self." `
            -replace "use fable_library_rust::System::Collections::Concurrent::ConcurrentStack_1;", "type ConcurrentStack_1<T> = T;" `
            -replace "use fable_library_rust::System::Threading::Tasks::TaskCanceledException;", "type TaskCanceledException = ();" `
            -replace "use fable_library_rust::System::TimeZoneInfo;", "type TimeZoneInfo = i64;"
    }
}

function GetFableVersion {
    $versions = Get-ChildItem -Path "$HOME/.nuget/packages/fable" -Directory
    $latest = $versions | Sort-Object LastWriteTime -Descending | Select-Object -First 1
    $latest.Name
}

function FixTypeScript {
    param (
        [Parameter(Mandatory, ValueFromPipeline)]
        $text
    )
    process {
        $text `
            -replace "\./lib/typescript/fable", "." `
            -replace "defaultOf\(\) \| 0", "0" `
            -replace "/fable_modules/fable-library-ts\.[\-\d\w\.]+/", "/deps/Fable/src/fable-library-ts/" `
            -replace "from `"\./deps/", "from `"../../polyglot/deps/" `
            -replace "from `"\.\./\.\./\.\./deps/", "from `"deps/polyglot/deps/"
    }
}

function FixTypeScriptExternal {
    param (
        [Parameter(Mandatory, ValueFromPipeline)]
        $text
    )
    process {
        $text `
            -replace "from `"../../../../deps/Fable", "from `"../../deps/polyglot/deps/Fable"
    }
}

function CopyTarget {
    param (
        $TargetDir,
        $root,
        [Parameter(Mandatory)]
        [string] $Language,
        [string] $Runtime
    )
    $_runtime = $Runtime -ne "" ? "_$Runtime" : ""
    $LanguageDir = "$TargetDir/target/$Language"

    function CopyItem {
        param (
            $lib,
            $name
        )
        $name = $Language -eq "py" -and @("threading", "platform") -contains $name ? "$($name)_" : $name
        $name = $Language -eq "py" ? $name.ToLower() : $name
        $from = "$LanguageDir/deps/spiral/lib/$lib/$name.$Language"
        if (!(Test-Path $from)) {
            $from = ResolveLink "$LanguageDir/deps/spiral/lib/$lib/$name.$Language"
        }
        if (!(Test-Path $from)) {
            $from = "$LanguageDir/lib/$lib/$name.$Language"
        }
        if (!(Test-Path $from)) {
            $from = ResolveLink "$LanguageDir/polyglot/lib/$lib/$name.$Language"
        }
        if ($lib -eq "spiral") {
            $to = ResolveLink "$root/deps/spiral/lib/$lib/$name$_runtime.$Language"
        } else {
            $to = ResolveLink "$root/lib/$lib/$name$_runtime.$Language"
        }
        # Write-Output "spiral/lib/spiral/lib.ps1/CopyItem / from: $from / to: $to"
        Copy-Item $from $to -Force

        $text = Get-Content $to
        $text = $text `
            -replace "`r`n", "`n"

        if ($Language -eq "rs") {
            $text = $text `
                | FixRust

            if ($Runtime -eq "contract" -and $name -in @("async_", "file_system", "networking", "runtime")) {
                $text = $text `
                    -replace "use fable_library_rust::Async_::Async;", "type Async<T> = T;"
            }
            if ($name -in @("threading")) {
                $text = $text `
                    -replace "use fable_library_rust::System::Threading::CancellationTokenSource;", "type CancellationTokenSource = ();"
            }
            if ($name -in @("common") -and !$Runtime) {
                $text = $text `
                    -replace "defaultOf\(\)", "defaultOf::<std::sync::Arc<dyn IDisposable>>()"
            }
            if ($Runtime -eq "contract") {
                $text = $text `
                    -replace "use fable_library_rust::DateTime_::DateTime;", "type DateTime = ();"
            }
            if ($name -in @("file_system") -and $Runtime -ne "contract") {
                $text = $text `
                    -replace "defaultOf\(\),", "defaultOf::<std::sync::Arc<dyn IDisposable>>()," `
                    -replace "getZero\(\),", "getZero::<std::sync::Arc<dyn IDisposable>>(),"
            }
            if ($name -in @("common") -and $Runtime -in @("wasm", "contract")) {
                $text = $text `
                    -replace "defaultOf\(\),", "defaultOf::<std::rc::Rc<dyn IDisposable>>(),"
            }
            if ($name -eq "file_system" -and $Runtime -in @("contract")) {
                $text = $text `
                    -replace "chrono::Utc", "()" `
                    -replace "chrono::Local", "()" `
                    -replace "chrono::DateTime", "Option" `
                    -replace "defaultOf\(\),", "defaultOf::<std::sync::Arc<dyn IDisposable>>()," `
                    -replace "getZero\(\),", "getZero::<std::sync::Arc<dyn IDisposable>>()," `
                    -replace "use fable_library_rust::Guid_::Guid;", "type Guid = ();"
            }
        }
        if ($Language -eq "ts") {
            $text = $text `
                -replace "this\$.tag", "(this$ as any)['tag']" `
                -replace "../../../../../../../../", "../../" `
                -replace "from `"../../../../../../../lib", "from `"../../../../../polyglot/lib" `
                | FixTypeScript `
                | FixTypeScriptExternal

            if ($name -in @("file_system")) {
                $text = $text `
                    -replace ", awaitTask, ", ", awaitPromise as awaitTask, " `
            }
        }
        if ($Language -eq "py") {
            $text = $text `
                -replace "from .....lib", "from ........polyglot.lib" `
                -replace "from .....lib", "from ........polyglot.lib"
        }

        $text | Set-Content $to
    }

    CopyItem "fsharp" "Common"
    CopyItem "spiral" "common"
    CopyItem "spiral" "date_time"
    CopyItem "spiral" "async_"
    CopyItem "spiral" "platform"
    CopyItem "spiral" "runtime"
    CopyItem "spiral" "threading"
    CopyItem "spiral" "networking"
    CopyItem "spiral" "file_system"
    CopyItem "spiral" "sm"
    CopyItem "spiral" "crypto"
    CopyItem "spiral" "trace"
    CopyItem "spiral" "lib"

    if ($Language -eq "rs") {
        { cargo fix --allow-dirty } | Invoke-Block -location $PSScriptRoot
        if (!($name -eq "runtime")) {
            { cargo fmt } | Invoke-Block -location $PSScriptRoot
        }

        if ($Runtime -eq "contract") {
            Set-Content "$root/deps/spiral/lib/spiral/date_time_contract.rs" ""
        }
    }

    if ($Language -eq "ts") {
        Remove-Item "$LanguageDir/fable_modules" -Recurse -Force -ErrorAction Ignore
    }
}

function GetTargetDir {
    param (
        [Parameter(Mandatory)]
        [string] $ProjectName
    )
    $root = "$PSScriptRoot/../../deps/polyglot"
    $result = ResolveLink "$root/target/Builder/$ProjectName"
    Write-Host "spiral/lib/spiral/lib.ps1/GetTargetDir / targetDir: $result"
    $result
}

function BuildFable {
    param (
        [Parameter(Mandatory)]
        [string] $TargetDir,
        [Parameter(Mandatory)]
        [string] $ProjectName,
        [Parameter(Mandatory)]
        [string] $Language,
        [string] $Runtime
    )
    $root = ResolveLink "$PSScriptRoot/../../deps/polyglot"

    Write-Host ("spiral/lib/spiral/lib.ps1/BuildFable / " + `
        "TargetDir: $TargetDir / ProjectName: $ProjectName / Language: $Language / Runtime: $Runtime / " + `
        "root: $root")

    { dotnet fable "$TargetDir/$ProjectName.fsproj" --optimize --noCache --lang $Language --extension ".$Language" --outDir $TargetDir/target/$Language --define $($IsWindows ? "_WINDOWS" : "_LINUX") $($Runtime ? @("--define", $Runtime) : @()) } | Invoke-Block -Location $root

    CopyTarget $TargetDir $root $Language $Runtime.ToLower()
}


function GetFsxModules {
    @("deps/spiral/lib/spiral/common.fsx", "deps/spiral/lib/spiral/sm.fsx", "deps/spiral/lib/spiral/crypto.fsx", "deps/spiral/lib/spiral/date_time.fsx", "deps/spiral/lib/spiral/async_.fsx", "deps/spiral/lib/spiral/threading.fsx", "deps/spiral/lib/spiral/networking.fsx", "deps/spiral/lib/spiral/platform.fsx", "deps/spiral/lib/spiral/runtime.fsx", "deps/spiral/lib/spiral/file_system.fsx", "deps/spiral/lib/spiral/trace.fsx", "deps/spiral/lib/spiral/lib.fsx")
}
