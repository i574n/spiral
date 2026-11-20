program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$IFDEF WINDOWS}{$MAXSTACKSIZE $10000000}{$ENDIF}
uses {$IFDEF UNIX}cthreads, {$ENDIF}SysUtils, Math;
type
  TTuple0 = record f0: AnsiString; f1: LongInt; end;
function method0(v0: AnsiString): TTuple0; forward;
function score_1(v0: LongInt; v1: AnsiString): LongInt; forward;
function TupleCreate0(f0: AnsiString; f1: LongInt): TTuple0;
begin
  Result.f0 := f0; Result.f1 := f1;
end;
function method0(v0: AnsiString): TTuple0;
var
  v1: LongInt;
begin
  v1 := LongInt(Length(v0));
  Result := TupleCreate0(v0, v1);
end;
function score_1(v0: LongInt; v1: AnsiString): LongInt;
var
  v2: LongInt;
  v3: LongInt;
begin
  v2 := LongInt(Length(v1));
  v3 := v2 + v0;
  Result := v3;
end;
function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: AnsiString;
  v2: LongInt;
  tmp3: TTuple0;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
begin
  v0 := 'qwe';
  tmp3 := method0(v0);
  v1 := tmp3.f0;
  v2 := tmp3.f1;
  v3 := score_1(v2, v1);
  v4 := score_1(v2, v1);
  v5 := v3 + v4;
  v6 := v5 - 12;
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
