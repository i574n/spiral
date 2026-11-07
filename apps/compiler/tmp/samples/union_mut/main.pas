program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TSpiralRc = class refc: LongInt; procedure DropFields; virtual; end;
  TMut0 = class;
  TMut0 = class(TSpiralRc) l0: LongInt; end;
  TUS0 = record tag: LongInt; c1_0: TMut0; end;
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
procedure SpiralRetain_TUS0(const x: TUS0); forward;
procedure SpiralRelease_TUS0(const x: TUS0); forward;
function SpiralKeep_TUS0(const x: TUS0): TUS0; forward;
function MutCreate0(a0: LongInt): TMut0;
begin
  Result := TMut0.Create; Result.l0 := a0;
end;
function US0_Missing: TUS0;
begin
  Result.tag := 0; 
end;
function US0_Held(a0: TMut0): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
procedure SpiralRetain_TUS0(const x: TUS0);
begin
  case x.tag of
    1: begin SpiralRetain(x.c1_0); end;
  end;
end;
procedure SpiralRelease_TUS0(const x: TUS0);
begin
  case x.tag of
    1: begin SpiralRelease(x.c1_0); end;
  end;
end;
function SpiralKeep_TUS0(const x: TUS0): TUS0;
begin
  SpiralRetain_TUS0(x); Result := x;
end;
function SpiralMain: LongInt;
var
  v0: TMut0;
  v1: Boolean;
  v4: TUS0;
  v5: TMut0;
  v6: LongInt;
  v7: Boolean;
begin
  v0 := MutCreate0(1);
  v1 := True;
  if v1 then begin
      SpiralRetain(v0);
      v4 := US0_Held(v0);
  end else begin
      v4 := US0_Missing;
  end;
  SpiralRelease(v0);
  case v4.tag of
      1: begin
          v5 := v4.c1_0;
          SpiralRetain(v5);
          SpiralRelease_TUS0(v4);
          v5.l0 := 7;
          v6 := v5.l0;
          SpiralRelease(v5);
          v7 := v6 = 7;
          if v7 then begin
              Result := 0;
          end else begin
              Result := 1;
          end;
      end;
      0: begin
          SpiralRelease_TUS0(v4);
          Result := 1;
      end;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
