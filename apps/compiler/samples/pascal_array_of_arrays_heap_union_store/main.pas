program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$IFDEF WINDOWS}{$MAXSTACKSIZE $10000000}{$ENDIF}
uses {$IFDEF UNIX}cthreads, {$ENDIF}SysUtils, Math;
type
  TSpiralRc = class refc: LongInt; procedure DropFields; virtual; end;
  TUH0 = class;
  TBoxArray1 = class;
  TBoxArray0 = class;
  TUH0 = class(TSpiralRc) tag: LongInt; c0_0: LongInt; c1_0: TUH0; c1_1: TUH0; procedure DropFields; override; end;
  TBoxArray1 = class(TSpiralRc) items: array of TUH0; procedure DropFields; override; end;
  TBoxArray0 = class(TSpiralRc) items: array of TBoxArray1; procedure DropFields; override; end;
procedure TSpiralRc.DropFields;
begin
end;
procedure SpiralRetain(o: TSpiralRc);
begin
  if o <> nil then Inc(o.refc);
end;
procedure SpiralRelease(o: TSpiralRc);
begin
  if o <> nil then begin Dec(o.refc); if o.refc < 0 then begin o.DropFields; o.Free; end; end;
end;
function SpiralKeep(o: TSpiralRc): TSpiralRc;
begin
  SpiralRetain(o); Result := o;
end;
procedure TUH0.DropFields;
begin
  SpiralRelease(c1_0); SpiralRelease(c1_1);
end;
function UH0_Leaf(a0: LongInt): TUH0;
begin
  Result := TUH0.Create; Result.tag := 0; Result.c0_0 := a0;
end;
function UH0_Node(a0: TUH0; a1: TUH0): TUH0;
begin
  Result := TUH0.Create; Result.tag := 1; Result.c1_0 := a0; Result.c1_1 := a1;
end;
procedure TBoxArray1.DropFields;
var i: NativeInt;
begin
  for i := 0 to High(items) do begin SpiralRelease(items[i]); end;
end;
procedure TBoxArray0.DropFields;
var i: NativeInt;
begin
  for i := 0 to High(items) do begin SpiralRelease(items[i]); end;
end;
function SpiralMain: LongInt;
var
  v0: TBoxArray0;
  tmp1: TBoxArray0;
  v1: TBoxArray1;
  tmp3: TBoxArray1;
  v2: TBoxArray1;
  v3: TUH0;
  v4: TBoxArray1;
  v5: TUH0;
  v6: LongInt;
  v7: TUH0;
  v8: TUH0;
begin
  tmp1 := TBoxArray0.Create;
  SetLength(tmp1.items, 1);
  v0 := tmp1;
  tmp3 := TBoxArray1.Create;
  SetLength(tmp3.items, 4);
  v1 := tmp3;
  SpiralRetain(v1); SpiralRelease(v0.items[0]); v0.items[0] := v1;
  SpiralRelease(v1);
  v2 := v0.items[0];
  SpiralRetain(v2);
  v3 := UH0_Leaf(40);
  SpiralRetain(v3); SpiralRelease(v2.items[0]); v2.items[0] := v3;
  SpiralRelease(v2);
  SpiralRelease(v3);
  v4 := v0.items[0];
  SpiralRetain(v4);
  SpiralRelease(v0);
  v5 := v4.items[0];
  SpiralRetain(v5);
  SpiralRelease(v4);
  case v5.tag of
      0: begin
          v6 := v5.c0_0;
          SpiralRelease(v5);
          Result := v6;
      end;
      1: begin
          v7 := v5.c1_0;
          v8 := v5.c1_1;
          SpiralRelease(v5);
          Result := 0;
      end;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
var SpiralExitCode: LongInt;
procedure SpiralRun;
begin
  {$IFDEF WINDOWS}DefaultSystemCodePage := CP_UTF8;{$ENDIF}
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
