program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$IFDEF WINDOWS}{$MAXSTACKSIZE $10000000}{$ENDIF}
uses {$IFDEF UNIX}cthreads, {$ENDIF}SysUtils, Math;
procedure target_global_0(v0: AnsiString); forward;
procedure target_global_0(v0: AnsiString);
begin
end;
function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: AnsiString;
  v2: AnsiString;
  v3: AnsiString;
  v4: AnsiString;
  v5: AnsiString;
  v6: AnsiString;
begin
  v0 := 'SPIRAL_TARGET_GLOBAL_RUST_PRELUDE_pos-p_B64:Ly9Q';
  target_global_0(v0);
  target_global_0(v0);
  v1 := 'SPIRAL_TARGET_GLOBAL_RUST_BEFORE_MAIN_pos-b_B64:Ly9C';
  target_global_0(v1);
  v2 := 'SPIRAL_TARGET_GLOBAL_RUST_AFTER_MAIN_test-item_B64:Zm4gc3BpcmFsX2F0dHJpYnV0ZV9zbW9rZSgpIHsKICAgIGFzc2VydF9lcSEoNiAqIDcsIDQyKTsKfQo=';
  target_global_0(v2);
  v3 := 'SPIRAL_ITEM_METADATA_TEST_test-item';
  target_global_0(v3);
  v4 := 'SPIRAL_TARGET_GLOBAL_DELPHI_PRELUDE_pos-p_B64:Ly9Q';
  target_global_0(v4);
  target_global_0(v4);
  v5 := 'SPIRAL_TARGET_GLOBAL_DELPHI_BEFORE_MAIN_pos-b_B64:Ly9C';
  target_global_0(v5);
  v6 := 'SPIRAL_TARGET_GLOBAL_DELPHI_AFTER_MAIN_test-item_B64:cHJvY2VkdXJlIFNwaXJhbFRhcmdldEdsb2JhbFNtb2tlOwpiZWdpbgogIGlmIDYgKiA3IDw+IDQyIHRoZW4gSGFsdCgxKTsKZW5kOwo=';
  target_global_0(v6);
  Result := 0;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
var SpiralExitCode: LongInt;
procedure SpiralRun;
begin
  {$IFDEF WINDOWS}SetTextCodePage(Output, CP_UTF8); SetTextCodePage(StdErr, CP_UTF8);{$ENDIF}
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  SpiralExitCode := SpiralMain;
  Flush(Output);
end;
{$IFNDEF WINDOWS}
function SpiralThreadMain(p: Pointer): PtrInt;
begin
  SpiralRun;
  Result := 0;
end;
var SpiralThread, SpiralThreadId: TThreadID;
{$ENDIF}
begin
  {$IFDEF WINDOWS}
  SpiralRun;
  Halt(SpiralExitCode);
  {$ELSE}
  SpiralThread := BeginThread(@SpiralThreadMain, nil, SpiralThreadId, 268435456);
  WaitForThreadTerminate(SpiralThread, 0);
  Halt(SpiralExitCode and 255);
  {$ENDIF}
end.
