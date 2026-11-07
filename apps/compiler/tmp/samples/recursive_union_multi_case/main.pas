program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TSpiralRc = class refc: LongInt; procedure DropFields; virtual; end;
  TUH0 = class;
  TUH0 = class(TSpiralRc) tag: LongInt; c2_0: LongInt; c2_1: TUH0; c2_2: TUH0; procedure DropFields; override; end;
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
function sum_0(v0: TUH0): LongInt; forward;
procedure TUH0.DropFields;
begin
  SpiralRelease(c2_1); SpiralRelease(c2_2);
end;
var UH0_Leaf_shared: TUH0 = nil;
function UH0_Leaf: TUH0;
begin
  if UH0_Leaf_shared = nil then begin UH0_Leaf_shared := TUH0.Create; UH0_Leaf_shared.tag := 0; UH0_Leaf_shared.refc := High(LongInt) div 2; end;
  Result := UH0_Leaf_shared;
end;
var UH0_Marker_shared: TUH0 = nil;
function UH0_Marker: TUH0;
begin
  if UH0_Marker_shared = nil then begin UH0_Marker_shared := TUH0.Create; UH0_Marker_shared.tag := 1; UH0_Marker_shared.refc := High(LongInt) div 2; end;
  Result := UH0_Marker_shared;
end;
function UH0_Node(a0: LongInt; a1: TUH0; a2: TUH0): TUH0;
begin
  Result := TUH0.Create; Result.tag := 2; Result.c2_0 := a0; Result.c2_1 := a1; Result.c2_2 := a2;
end;
function sum_0(v0: TUH0): LongInt;
var
  v1: LongInt;
  v2: TUH0;
  v3: TUH0;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
begin
  case v0.tag of
      0: begin
          SpiralRelease(v0);
          Result := 0;
      end;
      1: begin
          SpiralRelease(v0);
          Result := 0;
      end;
      2: begin
          v1 := v0.c2_0;
          v2 := v0.c2_1;
          v3 := v0.c2_2;
          SpiralRetain(v2);
          SpiralRetain(v2);
          SpiralRetain(v3);
          SpiralRelease(v0);
          v4 := sum_0(v2);
          SpiralRetain(v3);
          SpiralRelease(v2);
          v5 := sum_0(v3);
          SpiralRelease(v3);
          v6 := v4 + v5;
          v7 := v1 + v6;
          Result := v7;
      end;
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: TUH0;
  v3: TUH0;
  v4: TUH0;
  v5: TUH0;
  v6: LongInt;
  v7: LongInt;
begin
  v0 := 1;
  v1 := 2;
  v2 := UH0_Leaf;
  v3 := UH0_Marker;
  SpiralRetain(v2);
  SpiralRetain(v3);
  v4 := UH0_Node(v1, v2, v3);
  SpiralRetain(v4);
  SpiralRetain(v4);
  SpiralRelease(v2);
  SpiralRelease(v3);
  v5 := UH0_Node(v0, v4, v4);
  SpiralRetain(v5);
  SpiralRelease(v4);
  v6 := sum_0(v5);
  SpiralRelease(v5);
  v7 := v6 - 5;
  Result := v7;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
var SpiralExitCode: LongInt;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  SpiralExitCode := SpiralMain;
  if UH0_Leaf_shared <> nil then UH0_Leaf_shared.Free;
  if UH0_Marker_shared <> nil then UH0_Marker_shared.Free;
  Halt(SpiralExitCode);
end.
