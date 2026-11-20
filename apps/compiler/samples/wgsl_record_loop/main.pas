program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$IFDEF WINDOWS}{$MAXSTACKSIZE $10000000}{$ENDIF}
uses {$IFDEF UNIX}cthreads, {$ENDIF}SysUtils, Math;
type
  TTuple0 = record f0: LongInt; f1: LongInt; end;
function loop_0(v0: LongInt; v1: LongInt; v2: LongInt; v3: LongInt): TTuple0; forward;
function TupleCreate0(f0: LongInt; f1: LongInt): TTuple0;
begin
  Result.f0 := f0; Result.f1 := f1;
end;
function loop_0(v0: LongInt; v1: LongInt; v2: LongInt; v3: LongInt): TTuple0;
var
  v4: Boolean;
  v9: LongInt;
  v10: LongInt;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
  v8: LongInt;
  tmp7: TTuple0;
begin
  v4 := v1 >= v0;
  if v4 then begin
      v9 := v2;
      v10 := v3;
  end else begin
      v5 := v1 + 1;
      v6 := v2 + 1;
      tmp7 := loop_0(v0, v5, v6, v3);
      v7 := tmp7.f0;
      v8 := tmp7.f1;
      v9 := v7;
      v10 := v8;
  end;
  Result := TupleCreate0(v9, v10);
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
  tmp6: TTuple0;
  v6: LongInt;
begin
  v0 := 5;
  v1 := 0;
  v2 := 1;
  v3 := 2;
  tmp6 := loop_0(v0, v1, v2, v3);
  v4 := tmp6.f0;
  v5 := tmp6.f1;
  v6 := v4 + v5;
  Result := v6;
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
