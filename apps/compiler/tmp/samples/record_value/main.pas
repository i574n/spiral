program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$IFDEF WINDOWS}{$MAXSTACKSIZE $10000000}{$ENDIF}
uses {$IFDEF UNIX}cthreads, {$ENDIF}SysUtils, Math;
type
  TTuple0 = record f0: LongInt; f1: LongInt; f2: Boolean; end;
function method0(v0: LongInt): TTuple0; forward;
function method1(v0: LongInt; v1: LongInt; v2: Boolean): LongInt; forward;
function TupleCreate0(f0: LongInt; f1: LongInt; f2: Boolean): TTuple0;
begin
  Result.f0 := f0; Result.f1 := f1; Result.f2 := f2;
end;
function method0(v0: LongInt): TTuple0;
var
  v1: LongInt;
  v2: Boolean;
begin
  v1 := v0 + 2;
  v2 := v0 > 0;
  Result := TupleCreate0(v0, v1, v2);
end;
function method1(v0: LongInt; v1: LongInt; v2: Boolean): LongInt;
var
  v3: LongInt;
  v4: LongInt;
begin
  if v2 then begin
      v3 := v0 + v1;
      v4 := v3 - 4;
      Result := v4;
  end else begin
      Result := 1;
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: LongInt;
  v3: Boolean;
  tmp4: TTuple0;
begin
  v0 := 1;
  tmp4 := method0(v0);
  v1 := tmp4.f0;
  v2 := tmp4.f1;
  v3 := tmp4.f2;
  Result := method1(v1, v2, v3);
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
