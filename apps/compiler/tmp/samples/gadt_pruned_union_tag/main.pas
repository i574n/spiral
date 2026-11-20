program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$IFDEF WINDOWS}{$MAXSTACKSIZE $10000000}{$ENDIF}
uses {$IFDEF UNIX}cthreads, {$ENDIF}SysUtils, Math;
type
  TUS0 = record tag: LongInt;  end;
function SpiralDeclaredTag(tag: LongInt; const declared: array of LongInt): LongInt;
begin
  Result := declared[tag];
end;
function US0_First: TUS0;
begin
  Result.tag := 0; 
end;
function US0_Second: TUS0;
begin
  Result.tag := 1; 
end;
function SpiralMain: LongInt;
var
  v0: TUS0;
  v1: LongInt;
  v2: LongInt;
  v3: LongInt;
begin
  v0 := US0_Second;
  v1 := SpiralDeclaredTag(v0.tag, [1, 2]);
  v2 := v1 * 10;
  v3 := v2 + 2;
  Result := v3;
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
