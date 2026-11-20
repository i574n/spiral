program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$IFDEF WINDOWS}{$MAXSTACKSIZE $10000000}{$ENDIF}
uses {$IFDEF UNIX}cthreads, {$ENDIF}SysUtils, Math;
type
  TUS0 = record tag: LongInt; c0_0: LongInt; c1_0: LongInt; c1_1: AnsiString; end;
function method0(v0: LongInt; v1: AnsiString): TUS0; forward;
function US0_One(a0: LongInt): TUS0;
begin
  Result.tag := 0; Result.c0_0 := a0;
end;
function US0_Both(a0: LongInt; a1: AnsiString): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0; Result.c1_1 := a1;
end;
function method0(v0: LongInt; v1: AnsiString): TUS0;
var
  v2: Boolean;
begin
  v2 := v0 = 0;
  if v2 then begin
      Result := US0_One(0);
  end else begin
      Result := US0_Both(v0, v1);
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: AnsiString;
  v2: TUS0;
  v4: LongInt;
  v5: AnsiString;
  v6: Boolean;
  v8: Boolean;
  v7: Boolean;
  v3: LongInt;
begin
  v0 := 3;
  v1 := 'hi';
  v2 := method0(v0, v1);
  case v2.tag of
      1: begin
          v4 := v2.c1_0;
          v5 := v2.c1_1;
          v6 := v4 = 3;
          if v6 then begin
              v7 := v5 = 'hi';
              v8 := v7;
          end else begin
              v8 := False;
          end;
          if v8 then begin
              Result := 0;
          end else begin
              Result := 1;
          end;
      end;
      0: begin
          v3 := v2.c0_0;
          Result := 1;
      end;
  end;
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
