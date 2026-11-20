program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$IFDEF WINDOWS}{$MAXSTACKSIZE $10000000}{$ENDIF}
uses {$IFDEF UNIX}cthreads, {$ENDIF}SysUtils, Math;
type
  TTuple0 = record f0: Boolean; f1: Single; f2: LongInt; end;
function method0(v0: Single): TTuple0; forward;
function method1(v0: Boolean; v1: Single; v2: LongInt): LongInt; forward;
function TupleCreate0(f0: Boolean; f1: Single; f2: LongInt): TTuple0;
begin
  Result.f0 := f0; Result.f1 := f1; Result.f2 := f2;
end;
function method0(v0: Single): TTuple0;
var
  v1: Boolean;
begin
  v1 := v0 >= 3.5;
  Result := TupleCreate0(v1, v0, 7);
end;
function method1(v0: Boolean; v1: Single; v2: LongInt): LongInt;
var
  v3: Boolean;
  v4: LongInt;
begin
  if v0 then begin
      v3 := v1 >= 3.5;
      if v3 then begin
          v4 := v2 - 7;
          Result := v4;
      end else begin
          Result := 1;
      end;
  end else begin
      Result := 2;
  end;
end;
function SpiralMain: LongInt;
var
  v0: Single;
  v1: Boolean;
  v2: Single;
  v3: LongInt;
  tmp4: TTuple0;
begin
  v0 := 4.0;
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
