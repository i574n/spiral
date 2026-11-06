program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TSpiralRc = class refc: LongInt; procedure DropFields; virtual; end;
  TUH0 = class;
  TUH0 = class(TSpiralRc) tag: LongInt; c1_0: AnsiString; c1_1: TUH0; c1_2: TUH0; procedure DropFields; override; end;
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
function score_0(v0: TUH0): LongInt; forward;
procedure TUH0.DropFields;
begin
  SpiralRelease(c1_1); SpiralRelease(c1_2);
end;
var UH0_Empty_shared: TUH0 = nil;
function UH0_Empty: TUH0;
begin
  if UH0_Empty_shared = nil then begin UH0_Empty_shared := TUH0.Create; UH0_Empty_shared.tag := 0; UH0_Empty_shared.refc := High(LongInt) div 2; end;
  Result := UH0_Empty_shared;
end;
function UH0_Node(a0: AnsiString; a1: TUH0; a2: TUH0): TUH0;
begin
  Result := TUH0.Create; Result.tag := 1; Result.c1_0 := a0; Result.c1_1 := a1; Result.c1_2 := a2;
end;
function score_0(v0: TUH0): LongInt;
var
  v1: AnsiString;
  v2: TUH0;
  v3: TUH0;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
  v8: LongInt;
begin
  case v0.tag of
      0: begin
          SpiralRelease(v0);
          Result := 0;
      end;
      1: begin
          v1 := v0.c1_0;
          v2 := v0.c1_1;
          v3 := v0.c1_2;
          SpiralRetain(v2);
          SpiralRetain(v3);
          SpiralRelease(v0);
          v4 := LongInt(Length(v1));
          SpiralRetain(v2);
          v5 := score_0(v2);
          SpiralRelease(v2);
          v6 := v4 + v5;
          SpiralRetain(v3);
          v7 := score_0(v3);
          SpiralRelease(v3);
          v8 := v6 + v7;
          Result := v8;
      end;
  end;
end;
function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: AnsiString;
  v2: TUH0;
  v3: TUH0;
  v4: TUH0;
  v5: LongInt;
  v6: TUH0;
  v7: TUH0;
  v8: TUH0;
  v9: LongInt;
  v10: LongInt;
  v11: LongInt;
begin
  v0 := 'ab';
  v1 := 'qwe';
  v2 := UH0_Empty;
  SpiralRetain(v2);
  SpiralRetain(v2);
  v3 := UH0_Node(v1, v2, v2);
  SpiralRetain(v3);
  SpiralRetain(v3);
  SpiralRelease(v2);
  v4 := UH0_Node(v0, v3, v3);
  SpiralRetain(v4);
  SpiralRelease(v3);
  v5 := score_0(v4);
  SpiralRelease(v4);
  v6 := UH0_Empty;
  SpiralRetain(v6);
  SpiralRetain(v6);
  v7 := UH0_Node(v1, v6, v6);
  SpiralRetain(v7);
  SpiralRetain(v7);
  SpiralRelease(v6);
  v8 := UH0_Node(v0, v7, v7);
  SpiralRetain(v8);
  SpiralRelease(v7);
  v9 := score_0(v8);
  SpiralRelease(v8);
  v10 := v5 + v9;
  v11 := v10 - 16;
  Result := v11;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
var SpiralExitCode: LongInt;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  SpiralExitCode := SpiralMain;
  if UH0_Empty_shared <> nil then UH0_Empty_shared.Free;
  Halt(SpiralExitCode);
end.
