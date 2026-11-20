program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$IFDEF WINDOWS}{$MAXSTACKSIZE $10000000}{$ENDIF}
uses {$IFDEF UNIX}cthreads, {$ENDIF}SysUtils, Math;
type
  TTuple0 = record f0: LongInt; f1: LongInt; end;
function method0(v0: LongInt; v1: LongInt): TTuple0; forward;
function method1(v0: LongInt; v1: LongInt): LongInt; forward;
function TupleCreate0(f0: LongInt; f1: LongInt): TTuple0;
begin
  Result.f0 := f0; Result.f1 := f1;
end;
function method0(v0: LongInt; v1: LongInt): TTuple0;
begin
  Result := TupleCreate0(v0, v1);
end;
function method1(v0: LongInt; v1: LongInt): LongInt;
var
  v2: LongInt;
begin
  v2 := v0 + v1;
  Result := v2;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: LongInt;
  v3: LongInt;
  tmp4: TTuple0;
  v4: LongInt;
  v5: LongInt;
begin
  v0 := 20;
  v1 := 22;
  tmp4 := method0(v0, v1);
  v2 := tmp4.f0;
  v3 := tmp4.f1;
  v4 := method1(v2, v3);
  v5 := v4 - 42;
  Result := v5;
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
